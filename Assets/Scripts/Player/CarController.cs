using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float carAge = 0;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!gameManager.isStarted)
            return;
        CarSwap();
    }
    private void OnTriggerExit(Collider other)
    {
        
    }

    public void CarSwap()
    {
        if (carAge > 10 && 20 == carAge)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.tag = "Untagged";
            transform.GetChild(2).gameObject.tag = "Untagged";
            transform.GetChild(3).gameObject.tag = "Untagged";
            transform.GetChild(4).gameObject.tag = "Untagged";
            transform.GetChild(1).gameObject.tag = "Player";

        }
        if (carAge > 20 && 30 == carAge)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.tag = "Untagged";
            transform.GetChild(1).gameObject.tag = "Untagged";
            transform.GetChild(3).gameObject.tag = "Untagged";
            transform.GetChild(4).gameObject.tag = "Untagged";
            transform.GetChild(2).gameObject.tag = "Player";
        }
        if (carAge > 30 && 40 == carAge)
        {
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.tag = "Untagged";
            transform.GetChild(1).gameObject.tag = "Untagged";
            transform.GetChild(2).gameObject.tag = "Untagged";
            transform.GetChild(4).gameObject.tag = "Untagged";
            transform.GetChild(3).gameObject.tag = "Player";
        }
        if (carAge > 40)
        {
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.tag = "Untagged";
            transform.GetChild(1).gameObject.tag = "Untagged";
            transform.GetChild(2).gameObject.tag = "Untagged";
            transform.GetChild(3).gameObject.tag = "Untagged";
            transform.GetChild(4).gameObject.tag = "Player";
        }
        if (carAge < 10)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.tag = "Player";
            transform.GetChild(1).gameObject.tag = "Untagged";
            transform.GetChild(2).gameObject.tag = "Untagged";
            transform.GetChild(3).gameObject.tag = "Untagged";
            transform.GetChild(4).gameObject.tag = "Untagged";
        }
    }
}
