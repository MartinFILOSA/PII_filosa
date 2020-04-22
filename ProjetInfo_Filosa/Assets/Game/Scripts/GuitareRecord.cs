using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class GuitareRecord : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip audioSample;

    public float[] sampleNotes;
    public string noteHit;

    public string micToUse;
    public TextMeshProUGUI txtMic;
    private bool micDetect = false;

    public ButtonController[] boutons;

    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            if (device == micToUse) micDetect = true;
        }
        noteHit = "";
        foreach (var device in Microphone.devices) Debug.Log(device);
        audio = GetComponent<AudioSource>();
        if (micDetect)
        {
            audio.clip = Microphone.Start(micToUse, true, 1, 44100);
            audio.loop = true;
            while (!(Microphone.GetPosition(micToUse) > 0)) { }
            audio.Play();
            txtMic.text = "Microphone : " + micToUse;
        }
        
        else txtMic.text = "Pas de guitare détecté";
    }

    void Update()
    {
        noteHit = "";
        float[] spectrum = new float[4096];
        audio.GetSpectrumData(spectrum,0,FFTWindow.BlackmanHarris);
        
        sampleNotes = new float[6];
        
        audioSpectrumAnalysis(spectrum, sampleNotes);
        
        noteHit = getNoteHit();
        
    }
    
    private float getMax(float[] tab)
    {
        float m = tab[0];
        foreach(float f in tab)
        {
            if (f > m) m = f;
        }
        return m;
    }

    private void audioSpectrumAnalysis(float[] spectrum, float[] notes)     // Procédure qui permet d'isoler les plages de fréquences souhaitées
    {
        
        sampleNotes[0] = (spectrum[15] + spectrum[16]) / 2;
        sampleNotes[1] = (spectrum[20] + spectrum[21]) / 2;
        sampleNotes[2] = (spectrum[26] + spectrum[27] + spectrum[28]) / 3;
        sampleNotes[3] = (spectrum[36] + spectrum[37] + spectrum[35]) / 3;
        sampleNotes[4] = (spectrum[44] + spectrum[45] + spectrum[46]) / 3;
        sampleNotes[5] = (spectrum[60] + spectrum[61] + spectrum[62]) / 3;

    }

    private string getNoteHit()     //Fonction dont la sortie est la note jouée. Les conditions des boucles if ont été ajustées empiriquement.
    {
        string note = "";
        if (getMax(sampleNotes) == sampleNotes[0] && sampleNotes[0] > 0.001)
        {
            note = "Mi";
        }

        else if (getMax(sampleNotes) == sampleNotes[1] && sampleNotes[1] > 0.001)
        {
            note = "La";
        }

        else if (getMax(sampleNotes) == sampleNotes[2] && sampleNotes[2] > 0.001)
        {
            if (sampleNotes[0] > 0.001) note = "Mi";
            else note = "Ré";
        }

        else if (getMax(sampleNotes) == sampleNotes[3] && sampleNotes[3] > 0.0001)
        {
            if (sampleNotes[1] > 0.001) note = "La";
            else note = "Sol";
        }

        else if (getMax(sampleNotes) == sampleNotes[4] && sampleNotes[4] > 0.0001)
        {
            note = "Si";
        }

        else if (getMax(sampleNotes) == sampleNotes[5] && sampleNotes[5] > 0.00001)
        {
            note = "mi";
        }

        return note;
    }
}
