using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public bool startPlaying;
    public BeatScroller theBS;
    public Metronome m;
    public TextMeshProUGUI[] txtScore;

    public GuitareRecord guitarInput;

    public int scorePerNote = 100;
    private int multiplier;
    private int score;
    private int nbrHit;

    public static GameManager instance;

    void Start()
    {
        instance = this;
        score = 0;
        multiplier = 1;
        nbrHit = 0;
    }
    
    void Update()
    {

        if (!startPlaying)
        {
            if (theBS.hasStarted)
            {
                startPlaying = true;
            }
        }
    }

    public void noteHit()       //procédure qui incrémente le score si la note est jouée
    {
        nbrHit++;
        if (nbrHit == 4 && multiplier < 4)
        {
            multiplier *= 2;
            nbrHit = 0;
        }
        score += scorePerNote*multiplier;
        foreach (TextMeshProUGUI txt in txtScore)
        {
            txt.text = "Score : " + score;
        }

    }
    public void noteMiss()      //procédure remettant à zéro le multiplieur
    {
        Debug.Log("Note manquée");
        multiplier = 1;
        nbrHit = 0;
    }
}
