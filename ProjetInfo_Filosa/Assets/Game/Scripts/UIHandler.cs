using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    public GameObject menuPause;
    public GameManager UIJeu;
    public static bool enPause = false;
    
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            ActionPause();
        }
    }

    void Pause()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0f;
        enPause = true;
        

    }
    void Reprendre()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1f;
        enPause = false;
    }

    public void ActionPause()
    {
        if (enPause) Reprendre();
        else Pause();
    }

}
