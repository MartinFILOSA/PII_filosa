using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    
    public TextMeshProUGUI txtBPM;
    public Slider sdrBPM;


    void Awake()
    {
        Metronome.BPM = 120;
        txtBPM.text = "BPM : " + Metronome.BPM;
        sdrBPM.value = Metronome.BPM;
        Debug.Log(Metronome.BPM);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void setBPM()
    {
        Metronome.BPM = (int)(sdrBPM.value);
        txtBPM.text = "BPM : " + Metronome.BPM;
    }

}