using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObject : MonoBehaviour
{
    private HealthSystem health;

    void Awake()
    {
        health = GetComponent<HealthSystem>();    
    }

    private void OnEnable()
    {
        health.OnDeath += OnDeath;
    }

    private void OnDisable()
    {
        health.OnDeath -= OnDeath;
    }

    private void OnDeath()
    {
        Debug.Log($"{gameObject.name} death!");
        Destroy(gameObject);
    }
}
