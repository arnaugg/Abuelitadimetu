using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* ### UI CHANGES (Xavier) ### */
    public float remaining_time; // Variable de tiempo usada en el contador hacia el Game Over
    public float initial_time; // Variable de tiempo usada para determinar la cantidad de tiempo inicial que el jugador tiene hasta el Game Over
    public float time_fill_amount; // Variable utilizada para animar la imagen de UI relacionada con el contador hacia el Game Over 
    public int seconds_units; // Variable utilizada para el contador de las unidades de segundos en la cuenta atras hacia la pantalla de victoria
    public int seconds_tens; // Variable utilizada para el contador de las decenas de segundos en la cuenta atras hacia la pantalla de victoria
    public int minutes; // Variable utilizada para el contador de los minutos en la cuenta atras hacia la pantalla de victoria
    public int current_facts = 0; // Variable utilizada para llevar la cuenta de las curiosidades vistas por el jugador en la pantalla de victoria
    public static GameManager instance;
    public bool seen_fact_1 = false;
    public bool seen_fact_2 = false;
    public bool seen_fact_3 = false;
    public bool seen_fact_4 = false;
    public bool seen_fact_5 = false;
    /* ### END OF UI CHANGES (Xavier) ###*/

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}