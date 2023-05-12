using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIv3 : MonoBehaviour
{
    enum EState
    {
        Idle,
        Wander,
        Attack
    }

    Dictionary<EState, State> States;

    EState currentState;

    float currentTime;

    Vector3 direction;

    Transform player;

    private void Start()
    {
        States = new Dictionary<EState, State>();
        foreach (EState e in System.Enum.GetValues(typeof(EState)))
        {
            States.Add(e, new State());
        }

        States[EState.Idle].OnEnter = () => currentTime = 0.0f;

        States[EState.Wander].OnEnter = () =>
        {
            currentTime = 0.0f;
            float randomAngle = Random.Range(0.0f, 360.0f);
            direction = new Vector3(Mathf.Cos(randomAngle), 0.0f, Mathf.Sin(randomAngle));
        };

        States[EState.Idle].OnStay = IdleUpdate;
        States[EState.Wander].OnStay = WanderUpdate;
        States[EState.Attack].OnStay = AttackUpdate;

        currentState = EState.Idle;
        currentTime = 0.0f;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        States[currentState].OnStay?.Invoke();
    }

    void ChangeState(EState newState)
    {
        States[currentState].OnExit?.Invoke();
        States[newState].OnEnter?.Invoke();

        currentState = newState;
    }

    void IdleUpdate()
    {
        if (Vector3.Distance(player.position, transform.position) < 4.0f)
        {
            ChangeState(EState.Attack);
        }

        currentTime += Time.deltaTime;
        if (currentTime > 2.0f)
        {
            ChangeState(EState.Wander);
        }
    }

    void WanderUpdate()
    {
        transform.position += direction * Time.deltaTime;

        if (Vector3.Distance(player.position, transform.position) < 4.0f)
        {
            ChangeState(EState.Attack);
        }

        currentTime += Time.deltaTime;
        if (currentTime > 4.0f)
        {
            ChangeState(EState.Idle);
        }
    }

    void AttackUpdate()
    {
        direction = (player.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime;

        if (Vector3.Distance(player.position, transform.position) > 4.0f)
        {
            ChangeState(EState.Idle);
        }
    }
}