using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    Cinemachine.CinemachineVirtualCamera cam;
    [SerializeField] Transform[] target;

    private void Start()
    {
        cam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    private void Update()
    {

        if (cam.m_Follow == target[0].transform)
        {
            return;
        }
        else
        {
            cam.m_LookAt = target[1].transform;
            cam.m_Follow = target[1].transform;
        }
        
    }
}
