using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Path : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction end;
    public float speed;
    float distanceTraveled;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    private void Update()
    {
        if (!gameManager.isStarted)
            return;
        distanceTraveled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled, end);

    }
}
