using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollow : MonoBehaviour
{
    public Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screen = Input.mousePosition;
        screen.z = 0;
        Vector3 pos = Camera.ScreenToWorldPoint(screen);

        Vector3 dir = pos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x);

        transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.forward);
    }
}
