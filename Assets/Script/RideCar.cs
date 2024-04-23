using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RideCar : MonoBehaviour
{
    public GameObject player; // The player object
    public GameObject Car; // The car object
    public float interactDistance = 2.0f; // Distance within which interaction is possible
    public KeyCode rideKey = KeyCode.F; // Key to ride the car
    public bool isRiding = false; // Whether the player is riding the Car

    void Update()
    {
        // Calculate the distance between the player and the Car
        float distance = Vector3.Distance(player.transform.position, Car.transform.position);

        // Check if the player is within interaction range and presses the ride key
        if (distance <= interactDistance && Input.GetKeyDown(rideKey) && !isRiding)
        {
            Ride(); // Ride the Car
        }
        else if (isRiding && Input.GetKeyDown(rideKey))
        {
            Dismount(); // Dismount the Car
        }
    }

    void Ride()
    {
        isRiding = true;
        player.SetActive(false); // Disable player while riding
        // Set the Car as active and set its control (implement Car control separately)
        // Example: Car.GetComponent<CarControl>().enabled = true;
        Debug.Log("Riding the Car");
    }

    void Dismount()
    {
        isRiding = false;
        player.SetActive(true); // Enable player when dismounting
        // Disable Car control when dismounting
        // Example: Car.GetComponent<CarControl>().enabled = false;
        Debug.Log("Dismounting the Car");
    }
}
