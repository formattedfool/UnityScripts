using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject confirmQuitUI;

    void Start() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
    {
            if (GameIsPaused)
            {
               Resume();
            } else
            {
               Paused();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        confirmQuitUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void StartPaused()
    {
        pauseMenuUI.SetActive(true);
        confirmQuitUI.SetActive(false);
        GameIsPaused = false;
    }
    public void Paused()
    {
        pauseMenuUI.SetActive(true);
        confirmQuitUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("loading Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game!");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene1");
        Debug.Log("Starting Game!");
    }
    public void ConfirmQuit()
    {   
        confirmQuitUI.SetActive(true);
        Debug.Log("Are You Sure?");
    }
}
