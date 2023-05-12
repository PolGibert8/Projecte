using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator anim;

    [SerializeField]
    private float MaxSpeed = 42;
    // Start is called before the first frame update

    [SerializeField]
    [Range(0, 1)]
    private float _speedSmoother;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;

        float horitzontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        



        if (horitzontal > 0)
        {
            anim.SetFloat("Horizontal", horitzontal);
            //anim.SetBool("Right", true);
            movement += Vector3.right;
        }
        if (horitzontal < 0)
        {
            anim.SetFloat("Horizontal", horitzontal);
            //anim.SetBool("Left", true);
            movement -= Vector3.right;
        }
        if (vertical > 0)
        {
            anim.SetFloat("Vertical", vertical);
            //anim.SetBool("Up", true);
            movement += Vector3.up;
        }
        if (vertical < 0)
        {
            anim.SetFloat("Vertical", vertical);
            //anim.SetBool("Down", true);
            movement -= Vector3.up;
        }

        
        movement.Normalize();

        var targetVel = movement * MaxSpeed;
        _rigidbody.velocity = targetVel;

        if (Input.GetButton("Jump"))
        {
            Debug.Log("Fire button clicked!");
        }

    }
}


