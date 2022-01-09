using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public int win_screen_fact;
    private bool selected_fact;


    public GameObject fact_1;
    public GameObject fact_2;
    public GameObject fact_3;
    public GameObject fact_4;
    public GameObject fact_5;

    public Text Text_current_facts;

    void Start()
    {
        fact_1.SetActive(false);
        fact_2.SetActive(false);
        fact_3.SetActive(false);
        fact_4.SetActive(false);
        fact_5.SetActive(false);

        selected_fact = false;


        if (GameManager.instance.current_facts < 5)
        {
            GameManager.instance.current_facts += 1;
        }

        else
        {
            GameManager.instance.current_facts = 5;
            GameManager.instance.seen_fact_1 = false;
            GameManager.instance.seen_fact_2 = false;
            GameManager.instance.seen_fact_3 = false;
            GameManager.instance.seen_fact_4 = false;
            GameManager.instance.seen_fact_5 = false;
        }

        Text_current_facts.text = GameManager.instance.current_facts.ToString();

        do
        {
            win_screen_fact = Random.Range(1, 6);

            if (win_screen_fact == 1)
            {
                if (GameManager.instance.seen_fact_1 == false)
                {
                    GameManager.instance.seen_fact_1 = true;
                    fact_1.SetActive(true);
                    selected_fact = true;
                }

            }
            else
            {

            }

            if (win_screen_fact == 2)
            {
                if (GameManager.instance.seen_fact_2 == false)
                {
                    GameManager.instance.seen_fact_2 = true;
                    fact_2.SetActive(true);
                    selected_fact = true;
                }

            }
            else
            {

            }

            if (win_screen_fact == 3)
            {
                if (GameManager.instance.seen_fact_3 == false)
                {
                    GameManager.instance.seen_fact_3 = true;
                    fact_3.SetActive(true);
                    selected_fact = true;
                }

            }
            else
            {

            }

            if (win_screen_fact == 4)
            {
                if (GameManager.instance.seen_fact_4 == false)
                {
                    GameManager.instance.seen_fact_4 = true;
                    fact_4.SetActive(true);
                    selected_fact = true;
                }

            }
            else
            {

            }

            if (win_screen_fact == 5)
            {
                if (GameManager.instance.seen_fact_5 == false)
                {
                    GameManager.instance.seen_fact_5 = true;
                    fact_5.SetActive(true);
                    selected_fact = true;
                }

            }
            else
            {

            }


        } while (selected_fact == false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
