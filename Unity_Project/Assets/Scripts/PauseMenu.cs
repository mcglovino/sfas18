using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pause;

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Return()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause.activeSelf)
            {
                pause.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pause.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

}
