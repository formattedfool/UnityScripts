using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuMobile : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public GameObject confirmQuitUI;
    // Start is called before the first frame update
    public void Start()
    {
        pauseMenuUI.SetActive(true);
        confirmQuitUI.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game!");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("CutScenePreIntro");
        Debug.Log("Starting Game!");
    }
    public void ConfirmQuit()
    {   
        confirmQuitUI.SetActive(true);
        Debug.Log("Are You Sure?");
    }
}