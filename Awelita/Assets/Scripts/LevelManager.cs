using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public Image tiempo;
    //public float MaxTime;
    //public float CurrentTime;
    public Transform spawnPoint;
    //public GameObject panelGameOver;
    //public GameObject panelPause;
    //public GameObject panelWin;
    //public AudioClip levelSong;
    //public AudioClip gameOverSong;
    //private Audio Source musicSource;
    public Transform spawnEscalera1;
    public Transform spawnEscalera2;
    public Transform[] spawnPointsMedicamentos;
    public float timeToSpawn;
    public float timePass;

    // Start is called before the first frame update
    void Start()
    {
        //musicSource = this.GetComponent<AudioSource>();
        //Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timePass += Time.deltaTime;
        if (timePass >= timeToSpawn)
        {
            //spawnear medicamento
            spawnPointsMedicamentos();
            timePass = 0;
        }
    }

    void spawnPointsMedicamentos()
    {
        int random = Random.Range(0, 4);
        spawnPointsMedicamentos[random];
    }

    //decir que mire si hay spawn o no
}
