using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Patrol : MonoBehaviour
{
    public Transform [] points;
    int pointsIndex = 0;
    public float speed = 5f;
    Sequence sequence;

    private void Update()
    {
        Transform wp = points[pointsIndex];
        if (Vector3.Distance(transform.position, wp.position) < 0.001f)
        {
            pointsIndex = (pointsIndex + 1) % points.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);
        }
    }


}
