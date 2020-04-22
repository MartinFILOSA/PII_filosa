using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public TextMeshProUGUI txtBpm;
    public Slider sdrBPM;
    public Metronome metronome;

    public void changeBPMText()     //change le texte du BPM
    {
        Metronome.BPM = int.Parse(txtBpm.text);
    }
    public void changeBPMSlider()   //change la valeur du BPM
    {
        Metronome.BPM = (int)(sdrBPM.value);
        Metronome.updateBPM(metronome);
    }

    
    void Start()
    {
        sdrBPM.value = Metronome.BPM;
    }
    
    public void btnQuitter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

   

}
