using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public Metronome m;
    public float beatTempo;
    private float deltaPos;
    private BeatScroller bs;
    private Transform posInitiale;

    public bool hasStarted = false;
    
    void Start()
    {
        beatTempo = Metronome.BPM / 60f;
        bs = this;
        posInitiale = bs.transform;
    }

    void Update()
    {
        if (hasStarted)
        {
            transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);      //translation selon x d'une distance proportionnelle au tempo
            
        }
    }

}
