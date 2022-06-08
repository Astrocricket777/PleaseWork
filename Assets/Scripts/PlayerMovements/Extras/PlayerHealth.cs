using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int MaxHealth;
     public int Health;

    private TMP_Text text;

    private void Start()
    {
        //Finds the Health Text UI element contained in the SceneHolders Script
        text = FindObjectOfType<SceneHolders>().HealthText;
    
        Health = MaxHealth;
    }

    private void Update()
    {

        //Updates The Health Text UI Element
        text.text = Health.ToString();
    }

    //Subtracts Health Based On Int Pushed Through, EX:"PlayerHealth.Damage(25)" will deal 25 Damage to the player
    public void Damage(int Damage)
    {
        Health = (Health - Damage);
    }
}
