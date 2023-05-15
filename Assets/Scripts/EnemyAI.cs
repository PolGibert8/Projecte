using System.Collections;
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

    Vector3 direction;

    Transform player;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        InitFSM();

        currentTime = 0.0f;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        _rigidbody = GetComponent<Rigidbody2D>();
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
        if (Vector3.Distance(player.position, transform.position) < 4.0f)
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

        if (Vector3.Distance(player.position, transform.position) < 4.0f)
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
        direction = (player.position - transform.position).normalized;
        _rigidbody.velocity = direction;

        if (Vector3.Distance(player.position, transform.position) > 4.0f)
        {
            brain.ChangeState(EState.Idle);
        }
    }
}