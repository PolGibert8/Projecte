using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerSmooth : MonoBehaviour
{
    public Transform player;

    private Vector3 offset;

    public float Smoothing = 0.1f;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        SmoothFollow();
    }

    private void SmoothFollow()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Smoothing);
    }
}
