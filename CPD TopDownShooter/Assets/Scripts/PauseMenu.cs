using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// Controls the pause menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public string mainMenuScene;
    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    public GameObject pauseMenuWeb;

    public GameObject pauseFirstButton;
    public GameObject pauseFirstButtonWeb;


    public Controls controls;

    public GameObject touchPauseButton;


    bool onWeb = false;

    private void Start()
    {
#if (UNITY_WEBGL)
        onWeb = true;
#endif
        gameIsPaused = false;
        controls = new Controls();
        controls.Enable();
        controls.Player.Pause.performed += Pause_performed;

    }

    private void Pause_performed(InputAction.CallbackContext obj)
    {

        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        // If on web and using controller
        if (onWeb && FindObjectOfType<DetectControlMethod>().thePlayer.usePS4Controller)
        {
            pauseMenuWeb.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(pauseFirstButtonWeb);
        }

        // If on web and using mouse and keyboard
        if (onWeb)
        {
            pauseMenuWeb.SetActive(true);
           
        }

        // If not on web and using controller
        if (!onWeb && FindObjectOfType<DetectControlMethod>().thePlayer.usePS4Controller)
        {
            pauseMenuUI.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        }

        // If not on web and not using controller
        if (!onWeb)
        {
            pauseMenuUI.SetActive(true);
           
        }

        Time.timeScale = 0.0f;
        gameIsPaused = true;


        touchPauseButton.SetActive(false);

    }

    public void Resume()
    {
        if (onWeb)
        {
            pauseMenuWeb.SetActive(false);
        }
        else
        {
            pauseMenuUI.SetActive(false);
        }

        Time.timeScale = 1.0f;
        gameIsPaused = false;
        if (FindObjectOfType<VirtualPauseButton>().onMobile)
        { 
            touchPauseButton.SetActive(true); 
        }
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
