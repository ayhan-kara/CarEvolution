using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collect : MonoBehaviour
{
    [SerializeField] GameObject confetti;
    public float carAge = 0;
    Vector3 colliderPos;
    GameManager gameManager;
    Movement movement;
    Path path;
    CoinsManager coinsManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        movement = FindObjectOfType<Movement>();
        path = FindObjectOfType<Path>();
        coinsManager = FindObjectOfType<CoinsManager>();
    }

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
        if (other.tag == "FinishParticle")
        {
            Debug.Log("çarptý");
            confetti.gameObject.SetActive(true);
        }
        if (other.tag == "Coins")
        {
            coinsManager.AddCoins(other.transform.position,1);
            Destroy(other.gameObject);
        }
        if (other.tag == "FinishPoint")
        {
            carAge--;
            if (carAge == 0)
            {
                path.speed = 0f;
            }
            transform.DOMoveX(0f, 0.5f);
            gameManager.isFinished = true;
            movement.sensivity = 0f;
            movement.clampOnAxis = 0f;
            movement.isRotation = false;
            movement.rotateSensRadian = 0f;
        }
        if (other.tag == "Collectible")
        {
            carAge++;
            transform.DOMoveY(1f, 0.5f);
            Debug.Log(carAge);
        }
        else if (other.tag == "Obstacle")
        {
            carAge--;
            Debug.Log(carAge);
            if (carAge < 0 )
            {
                carAge = 0;
            }
            transform.DOMoveY(1f, 0.5f);
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
            transform.Rotate(Vector3.up, 5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Collectible")
        {
            transform.DOMoveY(0f, 0.5f);
        }
        else if (other.tag == "Obstacle")
        {
            transform.DOMoveY(0f, 0.5f);
        }
    }
}
