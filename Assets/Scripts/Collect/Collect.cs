using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public float carAge = 0;
    Vector3 colliderPos;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            colliderPos = hit.collider.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            carAge++;
            Vector3 playerPos1 = transform.localPosition;
            playerPos1.y += 0.3f;
            transform.localPosition = playerPos1;
            Debug.Log(carAge);
        }
        else if (other.tag == "Obstacle")
        {
            carAge--;
            Vector3 playerPos1 = transform.localPosition;
            playerPos1.y += 0.3f;
            transform.localPosition = playerPos1;
            Debug.Log(carAge);
        }
        switch (carAge)
        {
            case 1:
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 2:
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 3:
                transform.GetChild(2).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 4:
                transform.GetChild(3).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 5:
                transform.GetChild(4).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(false);
                break;
            default:
                break;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Oil")
        {
            transform.Rotate(Vector3.up, 10f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Collectible")
        {
            Vector3 playerPos2 = transform.localPosition;
            playerPos2.y -= 0.3f;
            transform.localPosition = playerPos2;
        }
        else if (other.tag == "Obstacle")
        {
            Vector3 playerPos2 = transform.localPosition;
            playerPos2.y -= 0.3f;
            transform.localPosition = playerPos2;
        }
    }
}
