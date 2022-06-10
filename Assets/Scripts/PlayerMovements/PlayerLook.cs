using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;

    public GameObject deathText;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    PlayerHealth health;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        health = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (health.dead)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            deathText.SetActive(true);
        }
        else if (!health.dead)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ProcessLook(Vector2 input)
    {
        if (!health.dead)
        {
            float mouseX = input.x;
            float mouseY = input.y;
            //calculate camera rotation for looking up and down
            xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);
            //apply this to out camera transform
            cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            //rotate player to look left and right
            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
        }
    }
}
