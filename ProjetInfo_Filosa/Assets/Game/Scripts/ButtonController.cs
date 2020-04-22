using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public GuitareRecord guitarInput;
    public string note;

    public KeyCode keyToPress;
    
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (guitarInput.noteHit == note)
        {
            theSR.sprite = pressedImage;
        }
        if (guitarInput.noteHit != note)
        {
            theSR.sprite = defaultImage;
        }
    }

   
}
