﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuScene;
    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    public GameObject pauseMenu;

    public GameObject pauseFirstButton;

    private void Start()
    {
        gameIsPaused = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0.0f;
                gameIsPaused = true;

                EventSystem.current.SetSelectedGameObject(null);

                EventSystem.current.SetSelectedGameObject(pauseFirstButton);
            }
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
