using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for UI elements

public class EButtonPopup : MonoBehaviour
{
    public Text popupText; // Reference to the text element in the popup UI

    private bool isInRange = false; // Flag to check if player is in interaction range

    void Start()
    {
        // Hide the popup initially
        popupText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check for "E" key press only when in interaction range
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Show the popup with desired message
            popupText.text = "Hi here is the hint."; // Change this to your actual message
            popupText.gameObject.SetActive(true);

            // Optional: Perform additional actions on E press (e.g., open inventory)
            // ... your code here ...
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if player enters interaction trigger area (e.g., collider around object)
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if player exits interaction trigger area
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            // Hide the popup if player leaves the area
            popupText.gameObject.SetActive(false);
        }
    }
}
