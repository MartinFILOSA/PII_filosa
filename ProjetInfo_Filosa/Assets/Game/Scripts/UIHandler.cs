using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    public GameObject menuPause;
    public GameObject menuDebut;
    public GameManager UIJeu;
    public static bool enPause = false;
    public BeatScroller bs;
    public GuitareRecord guitarInput;
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            actionPause();
        }
    }

    void pause()        //Mise en pause du jeu
    {
        menuPause.SetActive(true);
        Time.timeScale = 0f;
        enPause = true;
    }
    void reprendre()    //Reprise du jeu
    {
        menuPause.SetActive(false);
        Time.timeScale = 1f;
        enPause = false;
    }

    public void actionPause()
    {
        if (enPause) reprendre();
        else pause();
    }

    public void actionLancer()
    {
        menuDebut.SetActive(false);

    }

}
