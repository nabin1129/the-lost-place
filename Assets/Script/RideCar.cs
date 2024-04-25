using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideCar : MonoBehaviour
{
    public GameObject player; // The player object (e.g., Armature)
    public GameObject Car; // The car object
    public float interactDistance = 2.0f; // Distance within which interaction is possible
    public KeyCode rideKey = KeyCode.F; // Key to ride the car
    public bool isRiding = false; // Whether the player is riding the car
    public Transform carSeat; // Transform to position player when riding
    public FlyingCar carControls; // Car control script
    public ThirdPersonController PersonController; // Player control script
    public Camera MainCamera; // Reference to the main camera
    public Camera carCamera; // Reference to the car camera
    private Transform originalCameraParent; // Save the original camera parent

    void Start()
    {
        carControls.enabled = false;
        PersonController.enabled = true;
        if (MainCamera != null) MainCamera.enabled = true;
        if (carCamera != null) carCamera.enabled = false;
    }

    void Update()
    {
        // Calculate the distance between the player and the car
        float distance = Vector3.Distance(player.transform.position, Car.transform.position);

        // Check if within interaction distance and the key is pressed to ride/dismount
        if (distance <= interactDistance && Input.GetKeyDown(rideKey) && !isRiding)
        {
            Ride();
        }
        else if (isRiding && Input.GetKeyDown(rideKey))
        {
            Dismount();
        }
    }

    void Ride()
    {
        isRiding = true;
        carControls.enabled = true;
        PersonController.enabled = false;

        // Move the player to the car seat position
        player.transform.position = carSeat.position;
        player.transform.rotation = carSeat.rotation;

        // Parent the player to the car to ensure they move with it
        player.transform.parent = Car.transform;

        // Disable player movement components
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;

        // Activate the car camera and deactivate the main camera
        ToggleCamera(true);

        Debug.Log("Riding the Car");
    }

    void Dismount()
    {
        isRiding = false;

        carControls.enabled = false;
        PersonController.enabled = true;

        // Detach the player from the car
        player.transform.parent = null;

        // Re-enable player movement components
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<Rigidbody>().isKinematic = false;

        // Position the player slightly in front of the car when dismounting
        player.transform.position = Car.transform.position + Car.transform.forward * 2f;

        // Restore the original camera configuration
        ToggleCamera(false);

        Debug.Log("Dismounting the Car");
    }

    void ToggleCamera(bool activateCarCamera)
    {
        if (activateCarCamera)
        {
            if (MainCamera != null) MainCamera.enabled = false;
            if (carCamera != null) carCamera.enabled = true;
        }
        else
        {
            if (MainCamera != null) MainCamera.enabled = true;
            if (carCamera != null) carCamera.enabled = false;
        }
    }
}
