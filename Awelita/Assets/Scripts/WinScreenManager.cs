using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public int win_screen_fact;
    private bool selected_fact;
    private bool seen_fact_1 = false;
    private bool seen_fact_2 = false;
    private bool seen_fact_3 = false;
    private bool seen_fact_4 = false;
    private bool seen_fact_5 = false;


    public Image fact_1;
    public Image fact_2;
    public Image fact_3;
    public Image fact_4;
    public Image fact_5;
    
    public Text _current_facts;

    void Start()
    {
        fact_1.SetActive(false);
        fact_2.SetActive(false);
        fact_3.SetActive(false);
        fact_4.SetActive(false);
        fact_5.SetActive(false);

        selected_fact = false;

        do
        {
            win_screen_fact = int((5 * Rnd) + 1)

            if (win_screen_fact == 1)
            {
                if (seen_fact_1 == false)
                {
                    seen_fact_1 = true;
                    fact_1.SetActive(true);
                    selected_fact = true;
                }

            }

            if (win_screen_fact == 2)
            {
                if (seen_fact_2 == false)
                {
                    seen_fact_2 = true;
                    fact_2.SetActive(true);
                    selected_fact = true;
                }

            }

            if (win_screen_fact == 3)
            {
                if (seen_fact_3 == false)
                {
                    seen_fact_3 = true;
                    fact_3.SetActive(true);
                    selected_fact = true;
                }

            }

            if (win_screen_fact == 4)
            {
                if (seen_fact_4 == false)
                {
                    seen_fact_4 = true;
                    fact_4.SetActive(true);
                    selected_fact = true;
                }

            }

            if (win_screen_fact == 5)
            {
                if (seen_fact_5 == false)
                {
                    seen_fact_5 = true;
                    fact_5.SetActive(true);
                    selected_fact = true;
                }

            }


        }
        while (selected_fact == false)


        if(GameManager.instance.current_facts < 5)
        {
            GameManager.instance.current_facts += 1;
        }

        else
        {
            seen_fact_1 = false;
            seen_fact_2 = false;
            seen_fact_3 = false;
            seen_fact_4 = false;
            seen_fact_5 = false;
        }

    }

    public void MainMenu()
    {
       SceneManager.LoadScene(0);
    }

}
