using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isStarted = false;
    public bool isNotStarted = false;
    public bool isFinished = false;
    [SerializeField] GameObject speedBar;
    [SerializeField] GameObject ultraSpeedBar;
    [SerializeField] GameObject lowBar;
    [SerializeField] GameObject middle1Bar;
    [SerializeField] GameObject middle2Bar;
    [SerializeField] GameObject highBar;
    [SerializeField] GameObject ultraSpeedBar1;
    [SerializeField] GameObject ultraSpeedBar2;
    [SerializeField] GameObject playButton;

    Collect collect;

    private void Start()
    {
        collect = FindObjectOfType<Collect>();
    }

    private void Update()
    {
        Play();
        BarSwaps();
    }

    public void Play()
    {
        if (!isNotStarted && Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            isNotStarted = true;
            playButton.SetActive(false);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        isStarted = false;
    }

    public void BarSwaps()
    {
        switch (collect.carAge)
        {
            case 0:
                speedBar.gameObject.SetActive(true);
                lowBar.gameObject.SetActive(true);
                middle1Bar.gameObject.SetActive(false);
                middle2Bar.gameObject.SetActive(false);
                highBar.gameObject.SetActive(false);
                ultraSpeedBar.gameObject.SetActive(false);
                ultraSpeedBar1.gameObject.SetActive(false);
                ultraSpeedBar2.gameObject.SetActive(false);
                break;
            case 1:
                speedBar.gameObject.SetActive(true);
                lowBar.gameObject.SetActive(false);
                middle1Bar.gameObject.SetActive(true);
                middle2Bar.gameObject.SetActive(false);
                highBar.gameObject.SetActive(false);
                ultraSpeedBar.gameObject.SetActive(false);
                ultraSpeedBar1.gameObject.SetActive(false);
                ultraSpeedBar2.gameObject.SetActive(false);
                break;
            case 2:
                speedBar.gameObject.SetActive(true);
                lowBar.gameObject.SetActive(false);
                middle1Bar.gameObject.SetActive(false);
                middle2Bar.gameObject.SetActive(true);
                highBar.gameObject.SetActive(false);
                ultraSpeedBar.gameObject.SetActive(false);
                ultraSpeedBar1.gameObject.SetActive(false);
                ultraSpeedBar2.gameObject.SetActive(false);
                break;
            case 3:
                speedBar.gameObject.SetActive(true);
                lowBar.gameObject.SetActive(false);
                middle1Bar.gameObject.SetActive(false);
                middle2Bar.gameObject.SetActive(false);
                highBar.gameObject.SetActive(true);
                ultraSpeedBar.gameObject.SetActive(false);
                ultraSpeedBar1.gameObject.SetActive(false);
                ultraSpeedBar2.gameObject.SetActive(false);
                break;
            case 4:
                speedBar.gameObject.SetActive(true);
                lowBar.gameObject.SetActive(false);
                middle1Bar.gameObject.SetActive(false);
                middle2Bar.gameObject.SetActive(false);
                highBar.gameObject.SetActive(false);
                ultraSpeedBar.gameObject.SetActive(true);
                ultraSpeedBar1.gameObject.SetActive(true);
                ultraSpeedBar2.gameObject.SetActive(false);

                break;
            case 5:
                speedBar.gameObject.SetActive(true);
                lowBar.gameObject.SetActive(false);
                middle1Bar.gameObject.SetActive(false);
                middle2Bar.gameObject.SetActive(false);
                highBar.gameObject.SetActive(false);
                ultraSpeedBar.gameObject.SetActive(true);
                ultraSpeedBar1.gameObject.SetActive(false);
                ultraSpeedBar2.gameObject.SetActive(true);
                break;

            default:
                break;
        }
    }
}
