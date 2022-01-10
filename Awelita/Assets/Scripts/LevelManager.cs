using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{


    /* ### UI CHANGES (Xavier) ### */
    public Text Text_Seconds_Units; // Variable utilizada para actualizar el texto de la UI que muestra las unidades de segundos del contador hacia la pantalla de victoria
    public Text Text_Seconds_Tens; // Variable utilizada para actualizar el texto de la UI que muestra las decenas de segundos del contador hacia la pantalla de victoria
    public Text Text_Minutes; // Variable utilizada para actualizar el texto de la UI que muestra los minutos del contador hacia la pantalla de victoria
    public GameObject panelPause;
    public Image clock; // Variable utilizada para actualizar la imagen de la UI que muestra el contador de tiempo hacia el Game Over
    /* ### END OF UI CHANGES (Xavier) ###*/

    public Transform spawnPoint;
    //public AudioClip levelSong;
    //public AudioClip gameOverSong;
    //private Audio Source musicSource;
    public Transform spawnEscalera1;
    public Transform spawnEscalera2;
    //public Transform[] spawnPointsMedicamentos;
    public float timeToSpawn;
    public float timePass;

    public AudioSource musicsource;
    public AudioSource clicksource;

    public List<GameObject> objetos_a_desaparecer;

    // Start is called before the first frame update
    void Start()
    {

        //musicSource = this.GetComponent<AudioSource>();
        Time.timeScale = 1;

        /* ### UI CHANGES (Xavier) ###*/
        GameManager.instance.seconds_units = 0;
        GameManager.instance.seconds_tens = 0;
        GameManager.instance.minutes = 5; 
        StartCoroutine(Victory_CountDown());


        GameManager.instance.initial_time = 100; //"Aun Por Determinar";
        GameManager.instance.remaining_time = GameManager.instance.initial_time;
        StartCoroutine(Defeat_CountDown());
        /*### END OF UI CHANGES (Xavier) ###*/
    }

    // Update is called once per frame
    void Update()
    {
        timePass += Time.deltaTime;
        if (timePass >= timeToSpawn)
        {
            //spawnear medicamento
            // spawnPointsMedicamentos();
            timePass = 0;
        }
    }


    // void spawnPointsMedicamentos()
    //{
    // int random = Random.Range(0, 4);
    // spawnPointsMedicamentos[random];
    //}

    //decir que mire si hay spawn o no



    /* ### UI CHANGES (Xavier) ###*/
    // En este apartado de codigo se realizan todas las operciones involucradas con el contador hacia la pantalla de victoria. En esta funcion se actualiza el texto de la UI que muestra este contador al jugador y se redirige al jugador a la pantalla de victoria si se agota el tiempo
    IEnumerator Victory_CountDown()
    {
        
        do
        {

            Text_Seconds_Units.text = GameManager.instance.seconds_units.ToString();
            Text_Seconds_Tens.text = GameManager.instance.seconds_tens.ToString();
            Text_Minutes.text = GameManager.instance.minutes.ToString();

            yield return new WaitForSeconds(1f);

            GameManager.instance.seconds_units -= 1;

            if (GameManager.instance.seconds_units < 0)
            {
                GameManager.instance.seconds_units = 9;
                GameManager.instance.seconds_tens -= 1;
                
                    desaparecerobjeto();

                if (GameManager.instance.seconds_tens < 0)
                {
                    GameManager.instance.seconds_tens = 5;
                    GameManager.instance.minutes -= 1;
                }

            }



        } while (GameManager.instance.minutes >= 0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Escena de la pantalla de victoria (Aun Por Determinar)
    }

    // En este apartado de codigo se realizan todas las operciones involucradas con el contador hacia la pantalla de derrota. En esta funcion se actualiza la imagen de la UI que muestra este contador al jugador y se redirige al jugador a la pantalla de derrota si se agota el tiempo
    IEnumerator Defeat_CountDown()
    {
        do
        {
            yield return new WaitForSeconds(1f);

            GameManager.instance.remaining_time -= 1f;

            GameManager.instance.time_fill_amount = GameManager.instance.remaining_time / GameManager.instance.initial_time;

            clock.fillAmount = GameManager.instance.time_fill_amount;

        } while (GameManager.instance.remaining_time >= 0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // Escena de la pantalla de derrota (Aun Por Determinar)
    }

    // Este apartado de codigo se encarga de que el juego cierre el menu de pausa si se pulsa el boton de continuar
    public void Continue()
    {
        clicksource.Play();
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }

    // Este apartado de codigo se encarga de que el juego redirija al jugador al menu principal si se pulsa el boton de ir al menu principal en el menu de pausa
    public void MainMenu()
    {
        clicksource.Play();
        SceneManager.LoadScene(0);
    }

    // Este apartado de codigo se encarga de que el juego despliegue el menu de pausa si se pulsa el boton de pausa
    public void PauseMenu()
    {
        clicksource.Play();
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }

    public void desaparecerobjeto()
    {
        int azar = Random.Range(0, objetos_a_desaparecer.Count);
        StartCoroutine(thanos(objetos_a_desaparecer[azar]));
        objetos_a_desaparecer.RemoveAt(azar);
    }

    IEnumerator thanos(GameObject objeto)
    {
        float tiempo = 0;
        Color colorobjeto = Color.white;
        while  (tiempo <= 2)
        {
            tiempo += Time.deltaTime;
            colorobjeto.a -= Time.deltaTime;
            for (int i = 0; i < objeto.transform.childCount; i++)
            {
                objeto.transform.GetChild(i).GetComponent<SpriteRenderer>().color = colorobjeto;
            }
            yield return null;
        }
    }


    /*### END OF UI CHANGES (Xavier) ###*/
}
