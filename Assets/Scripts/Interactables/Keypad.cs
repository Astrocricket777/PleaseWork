using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    public PlayerHealth health;
   
    protected override void Interact()
    {
        Debug.Log("Interacted With " + gameObject.name);
        //Put what you want to happen after the interaction here
        health.Damage(5);
    }
}
