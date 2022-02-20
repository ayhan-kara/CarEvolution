using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSwap : MonoBehaviour
{
    public enum Cars { firstCar,secondCar,thirdCar,fourthCar,fifthCar}
    public Cars cars;
    GameManager gameManager;
    Movement movement;
    CarController carController;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        movement = FindObjectOfType<Movement>();
        carController = FindObjectOfType<CarController>();
    }

    public void CarSwaps(GameObject first,GameObject second,GameObject third,GameObject fourth, GameObject fifth,Vector3 target, Transform parent)
    {
        switch (cars)
        {
            case Cars.firstCar:
                if (carController.carAge <= 10)
                {
                    Instantiate(first, target, Quaternion.identity, parent);
                }
                break;
            case Cars.secondCar:
                if (carController.carAge > 10)
                {
                    Instantiate(second, target, Quaternion.identity, parent);
                }
                break;
            case Cars.thirdCar:
                if (carController.carAge > 20)
                {
                    Instantiate(third, target, Quaternion.identity, parent);
                }
                break;
            case Cars.fourthCar:
                if (carController.carAge > 30)
                {
                    Instantiate(fourth, target, Quaternion.identity, parent);
                }
                break;
            case Cars.fifthCar:
                if (carController.carAge > 40)
                {
                    Instantiate(fifth, target, Quaternion.identity, parent);
                }
                break;
            default:
                break;
        }
    }

}
