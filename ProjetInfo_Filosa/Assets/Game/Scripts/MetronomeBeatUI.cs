using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetronomeBeatUI : MonoBehaviour
{

    public AudioClip audioUn;
    public AudioClip audioAutres;
    public Metronome m;

    private Animator animator;
    private AudioSource audioSource;
    

    
    void Awake()
    {
        Metronome.OnTick += OnTick;
        animator = GetComponent<Animator>();
        audioSource = m.GetComponent<AudioSource>();
    }

    void OnTick(int tickCount, int measure, int beat)
    {
        Debug.Log(beat);
        animator = m.metronomeSprite[beat].GetComponent<Animator>();
        animator.SetTrigger("Tick");
        if (beat == 0) audioSource.PlayOneShot(audioUn);
        else audioSource.PlayOneShot(audioAutres);

       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
