using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    Movimiento velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = GetComponent<Movimiento>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collider2D collision)
    {
        velocity.MaxSpeed *= 2;
        Destroy(gameObject);
    }
}
