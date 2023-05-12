using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float Speed = 10;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        SetVelocity();
    }

    void SetVelocity()
    {
        _rigidbody.velocity = transform.right * Speed;
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {        
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
