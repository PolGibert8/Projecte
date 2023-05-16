﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum EState
    {
        Idle,
        Wander,
        Attack
    }

    FSM<EState> brain;

    float currentTime;

    public float enemyFireRate = 2.0f;

    Vector3 direction;

    Transform player;

    Gun gun;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        InitFSM();

        currentTime = 0.0f;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        _rigidbody = GetComponent<Rigidbody2D>();

        gun = GetComponentInChildren<Gun>();
    }

    private void InitFSM()
    {
        brain = new FSM<EState>(EState.Idle);

        brain.SetOnEnter(EState.Idle, () => currentTime = 0.0f);

        brain.SetOnEnter(EState.Wander, () =>
        {
            currentTime = 0.0f;
            float randomAngle = Random.Range(0.0f, 360.0f);
            direction = new Vector3(Mathf.Cos(randomAngle), 0.0f, Mathf.Sin(randomAngle));
        });

        brain.SetOnEnter(EState.Attack, () => currentTime = 0.0f);

        brain.SetOnStay(EState.Idle, IdleUpdate);
        brain.SetOnStay(EState.Wander, WanderUpdate);
        brain.SetOnStay(EState.Attack, AttackUpdate);
    }

    private void Update()
    {
        brain.Update();
    }

    void IdleUpdate()
    {
        if (Vector3.Distance(player.position, transform.position) < 6.0f)
        {
            brain.ChangeState(EState.Attack);
        }

        currentTime += Time.deltaTime;
        if (currentTime > 2.0f)
        {
            brain.ChangeState(EState.Wander);
        }
    }

    void WanderUpdate()
    {
        _rigidbody.velocity = direction;

        if (Vector3.Distance(player.position, transform.position) < 6.0f)
        {
            brain.ChangeState(EState.Attack);
        }

        currentTime += Time.deltaTime;
        if (currentTime > 4.0f)
        {
            brain.ChangeState(EState.Idle);
        }
    }

    void AttackUpdate()
    {
        currentTime += Time.deltaTime;
        direction = (player.position - transform.position).normalized;
        _rigidbody.velocity = direction;
        if (currentTime >= enemyFireRate)
        {
            gun.Fire();
            currentTime = 0.0f;
        }

        if (Vector3.Distance(player.position, transform.position) > 6.0f)
        {
            brain.ChangeState(EState.Idle);
        }
    }
}