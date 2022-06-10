using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    public PlayerHealth health;
   
    protected override void Interact()
    {
        Debug.Log("Interacted With " + gameObject.name);
        health.Damage(5);
    }
}
