using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;
    private PlayerUI playerUI;

    private InputManager inputManager;

    void Start() 
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);

        // Any Data Of The Object We Hit With The Raycast Will Be Stored Here.
        RaycastHit hitinfo;

        // Getting The Position Of The Camera And The Forward Vector.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        // Drawing A Visual Representation Of the Raycast.
        Debug.DrawRay(ray.origin, ray.direction * distance);

        // Shooting A Ray From The Camera Storing The Data From The Object That We Hit In The "hitinfo" Variable.
        if (Physics.Raycast(ray, out hitinfo, distance, mask))
        {
            // If The Object That We Hit Has The "Interactable" Script Then Run The Script Inside Of This If Statement.
            if (hitinfo.collider.GetComponent<Interactable>() != null)
            {
                // Making A Variable For The interactable that we hit.
                 Interactable interactable = hitinfo.collider.GetComponent<Interactable>();

                // Debuging The Prompt Message From The Interactable Object We Hit!
                playerUI.UpdateText(interactable.promptMessage);

                // If We Press Down "F" While Looking At An Interactable, Then Run The Script Inside Of This Statement.
                if (inputManager.onFoot.Interact.triggered)
                {
                    // This Will run The BaseInteract Method Which Inherits to Any Script Inheriting The Script.
                    interactable.BaseInteract();
                }
            }
        }
    }
}
