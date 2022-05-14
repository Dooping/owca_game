using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    public static bool gameIsPaused;

    private void Awake()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapePressed();
        }
    }

    public void EscapePressed()
    {
        gameIsPaused = !gameIsPaused;
        PauseGame();
    }

    private void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            menu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            menu.SetActive(false);
        }
    }
}
