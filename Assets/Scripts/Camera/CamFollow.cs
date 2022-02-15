using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desPos = target.transform.position + offset;
        Vector3 smoothedSpeed = Vector3.Lerp(transform.position, desPos, smoothSpeed);
        transform.position = smoothedSpeed;

    }
}
