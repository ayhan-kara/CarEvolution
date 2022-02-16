using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    CarController carController;
    public Material material1;

    private void Start()
    {
        carController = FindObjectOfType<CarController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().material = material1;
            carController.carAge -= 10;
            Debug.Log(carController.carAge);
        }
    }
}
