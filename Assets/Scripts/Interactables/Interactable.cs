using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //public bool UseEvents;
    public string promptMessage;


    public void BaseInteract()
    {
        //if (Event)
         //{
           //GetComponent<InteractionEvent>().OnInteract.Invoke();
         //}

        Interact();
    }

    protected virtual void Interact()
    {
        // There Will Be No Code Here... Yet...
    } 
}
