using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathbuttons : MonoBehaviour
{

    public GameObject deathGui;

    public PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        //health = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deathrespawn()
    {
        health.dead = false;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        deathGui.SetActive(false);
    }
}
