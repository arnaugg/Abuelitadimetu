using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource musicsource;
    public AudioSource clicksource;
    public GameObject pop_how_to_play;

    void Start()
    {

    Time.timeScale = 1;

    }
    
    public void StartGame()
    {
       clicksource.Play();
       SceneManager.LoadScene(1);
    }


    public void ExitGame()
    {
        clicksource.Play();
        Application.Quit();
    }

    public void HowToPlay()
    {
        pop_how_to_play.SetActive(true);
    }

    public void Close_HowToPlay()
    {
        pop_how_to_play.SetActive(false);
    }
}
