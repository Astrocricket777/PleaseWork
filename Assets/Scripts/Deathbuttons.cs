using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathbuttons : MonoBehaviour
{

    public GameObject deathGui;
    public GameObject player;

    public Transform RespawnPosition;

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
        health.Health = health.MaxHealth;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        deathGui.SetActive(false);

        player.transform.position = RespawnPosition.position;
    }
}
