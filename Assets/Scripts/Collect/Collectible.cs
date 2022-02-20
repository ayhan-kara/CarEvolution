using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Material material1;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().material = material1;
        }
    }
}
