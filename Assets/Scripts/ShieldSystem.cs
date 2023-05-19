using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSystem : MonoBehaviour, IDamageTaker
{
    [SerializeField]
    private float maxShield = 5;

    public float MaxHealth => maxShield;
    public float CurrentShield { get; private set; }
    public float CurrentHealth { get; private set; }
    public bool Dead { get; private set; }

    public delegate void OnDeathDelegate();
    public OnDeathDelegate OnDeath;

    public delegate void OnHitDelegate(float fraction);
    public OnHitDelegate OnHit;

    protected virtual void Start()
    {
        CurrentShield = 0;
        Dead = false;
    }

    public virtual void TakeDamage(float amount)
    {
        if (CurrentShield != 0.0f)
        {
            CurrentShield -= amount;
            OnHit?.Invoke(CurrentShield / MaxHealth);
        }
        



    }

    protected virtual void Die()
    {
        OnDeath?.Invoke();
        Dead = true;
    }
}
