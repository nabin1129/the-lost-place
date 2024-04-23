using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RideCar : MonoBehaviour
{
    public GameObject player; // The player object (Armature)
    public GameObject Car; // The car object
    public float interactDistance = 2.0f; // Distance within which interaction is possible
    public KeyCode rideKey = KeyCode.F; // Key to ride the car
    public bool isRiding = false; // Whether the player is riding the car
    public Transform carSeat; // Transform to position player when riding

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, Car.transform.position);

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

        // Disable player movement components (replace with specific component names)
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;

        // Set the Car as active and set its control (implement Car control separately)
        // Example: Car.GetComponent<CarControl>().enabled = true;
        Debug.Log("Riding the Car");
    }

    void Dismount()
    {
        isRiding = false;

        // Enable player movement components
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<Rigidbody>().isKinematic = false;

        // Disable Car control when dismounting
        // Example: Car.GetComponent<CarControl>().enabled = false;
        Debug.Log("Dismounting the Car");
    }
}