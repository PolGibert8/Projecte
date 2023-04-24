using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        float horitzontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horitzontal > 0)
        {
            movement += Vector3.right;
        }
        if (horitzontal < 0)
        {
            movement -= Vector3.right;
        }
        if (vertical > 0)
        {
            movement += Vector3.up;
        }
        if (vertical < 0)
        {
            movement -= Vector3.up;
        }

        movement.Normalize();

        transform.position += movement * Time.deltaTime;

        if (Input.GetButton("Jump"))
        {
            Debug.Log("Fire button clicked!");
        }

    }
}
