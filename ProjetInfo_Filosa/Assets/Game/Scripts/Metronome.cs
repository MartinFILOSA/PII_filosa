using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Metronome : MonoBehaviour
{
    //Partie UI
    public GameObject[] metronomeSprite;
    public TextMeshProUGUI[] txtBPM;
    public Slider sdrBPM;
    

    // BPM voulu partagé par toute l'interface
    public static int BPM { get; set; }
    public BeatScroller tabExo;
    public GameManager gm;

    private float beatsPerMinute = BPM;
    private float beatsPerMeasure = 4;

    private bool actif = false;

    public delegate void TickAction(int tickCount, int measure, int beat);
    public static event TickAction OnTick;


    void Awake()
    {
        if (BPM == 0) BPM = 120;
        updateBPM(this);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && actif == false)
        {
            lancerMetronome(this, tabExo);
        }
    }

    private IEnumerator Ticker()
    {
        actif = true;
        int tickCount = 0;
        
        while (actif)       //Boucle infinie qui recommence à intervalle régulier. Chaque itération est un clic du métronome.
        {

            float intervalTime = 60f / beatsPerMinute;
            float startTime = Time.time;

            int measure = (int)Math.Floor(tickCount / beatsPerMeasure);
            int beat = (int)(tickCount % beatsPerMeasure);


            if (OnTick != null)
            {
                OnTick(tickCount, measure, beat);
            }

            float duration = Time.time - startTime;
            float waitTime = intervalTime - duration;
            tickCount++;

            yield return new WaitForSeconds(waitTime);
            
        }

    }

    public static void updateBPM(Metronome m) //Met à jour le BPM dans tous les éléments nécessaires
    {
        foreach (TextMeshProUGUI txt in m.txtBPM)
        {
            txt.text = "BPM : " + BPM;
        }
        m.beatsPerMinute = BPM;
        m.tabExo.beatTempo = BPM/60f;
        m.sdrBPM.value = BPM;
        
    }

    public static void lancerMetronome(Metronome m, BeatScroller tab)
    {
        m.StartCoroutine(m.Ticker());
        tab.hasStarted = true;
    }
    
}
