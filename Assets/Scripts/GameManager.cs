using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isStarted = false;
    public bool isNotStarted = false;
    public bool isFinished = false;

    private void Update()
    {
        if (!isNotStarted && Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            isNotStarted = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        isStarted = false;
    }
}
