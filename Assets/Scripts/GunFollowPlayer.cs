using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollowPlayer : MonoBehaviour
{
    public Camera Camera;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.position;

        Vector3 dir = pos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x);

        transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.forward);
    }
}
