using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
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
        }
        else if (!health.dead)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // The PLayer Can't Look Around Because Your Not Calling The Method Anywhere, Looks Like You Need To Call It In The Update Then Give It A Vector 2 As An Argument.
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
