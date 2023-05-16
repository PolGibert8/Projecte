using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillPowerup : MonoBehaviour
{
    public float Damage = 5.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<IDamageTaker>();
        if (health != null)
        {
            health.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }


}
