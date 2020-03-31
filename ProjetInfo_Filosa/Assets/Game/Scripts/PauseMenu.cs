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

    public void changeBPMText()
    {
        Metronome.BPM = int.Parse(txtBpm.text);
    }
    public void changeBPMSlider()
    {
        Metronome.BPM = (int)(sdrBPM.value);
        Metronome.updateBPM(metronome);
    }


    // Start is called before the first frame update
    void Start()
    {
        sdrBPM.value = Metronome.BPM;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void btnQuitter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

   

}
