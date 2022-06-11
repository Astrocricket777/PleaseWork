using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    private PlayerHealth health;
    void Start()
    {
        health = GetComponent<PlayerHealth>();
    }
   
    protected override void Interact()
    {
        Debug.Log("Interacted With " + gameObject.name);
        //Put what you want to happen after the interaction here
    }
}
