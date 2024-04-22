using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RideBike : MonoBehaviour
{
    public GameObject player; // The player object
    public GameObject bike; // The bike object
    public float interactDistance = 2.0f; // Distance within which interaction is possible
    public KeyCode rideKey = KeyCode.E; // Key to ride the bike
    public bool isRiding = false; // Whether the player is riding the bike

    void Update()
    {
        // Calculate the distance between the player and the bike
        float distance = Vector3.Distance(player.transform.position, bike.transform.position);

        // Check if the player is within interaction range and presses the ride key
        if (distance <= interactDistance && Input.GetKeyDown(rideKey) && !isRiding)
        {
            Ride(); // Ride the bike
        }
        else if (isRiding && Input.GetKeyDown(rideKey))
        {
            Dismount(); // Dismount the bike
        }
    }

    void Ride()
    {
        isRiding = true;
        player.SetActive(false); // Disable player while riding
        // Set the bike as active and set its control (implement bike control separately)
        // Example: bike.GetComponent<BikeControl>().enabled = true;
        Debug.Log("Riding the bike");
    }

    void Dismount()
    {
        isRiding = false;
        player.SetActive(true); // Enable player when dismounting
        // Disable bike control when dismounting
        // Example: bike.GetComponent<BikeControl>().enabled = false;
        Debug.Log("Dismounting the bike");
    }
}
