using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public string noteToHit;
    public GuitareRecord guitarInput;

    public KeyCode keyToPress;
    
    
    void Update()
    {
        if (guitarInput.noteHit == noteToHit)
        {
            if (canBePressed)       //Vérifie que la note peut être activée, la fait disparaitre si le bouton est déclenché
            {
                gameObject.SetActive(false);

                GameManager.instance.noteHit();
                guitarInput.noteHit = "";
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) //Comportement à la collision entre les boutons et les notes.
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            GameManager.instance.noteMiss();
        }
    }
}
