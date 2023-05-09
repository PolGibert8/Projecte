using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionFromMouse : MonoBehaviour
{

    public Camera Camera;
    // Update is called once per frame
    void Update()
    {
        SetPosition();
    }

    void SetPosition()
    {
        Vector3 screen = Input.mousePosition;
        screen.z = 0;
        Vector3 pos = Camera.ScreenToWorldPoint(screen);
        transform.position = pos;
    }
}
