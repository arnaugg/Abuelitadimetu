using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatScreenManager : MonoBehaviour
{

    public Image nieta;
    public AudioSource musicsource;

    void Start()
    {
        StartCoroutine(thanos());
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator thanos()
    {
        float tiempo = 0;
        Color colorobjeto = Color.white;
        while (tiempo <= 4)
        {
            tiempo += Time.deltaTime;
            colorobjeto.a -= Time.deltaTime / 3;
            
                nieta.color = colorobjeto;
            
            yield return null;
        }
    }
}