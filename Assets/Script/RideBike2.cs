using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class RideBike2 : MonoBehaviour
{
    public GameObject player; // The player object
    public GameObject bike; // The bike object
    public Transform bikeSeat; // The point on the bike where the player sits
    public float interactDistance = 2.0f; // Distance to interact
    public KeyCode rideKey = KeyCode.E; // Key to ride
    public MonoBehaviour playerControlScript; // Player's control script
    public MonoBehaviour bikeControlScript; // Bike's control script
    public bool isRiding = false; // Riding state

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, bike.transform.position);

        if (distance <= interactDistance && Input.GetKeyDown(rideKey))
        {
            if (!isRiding)
            {
                Ride(); // Ride the bike
            }
            else
            {
                Dismount(); // Dismount from the bike
            }
        }
    }

    void Ride()
    {
        isRiding = true;
        // Parent the player to the bike seat
        player.transform.SetParent(bikeSeat, true);
        // Set player's position to the bike seat and reset rotation
        player.transform.localPosition = Vector3.zero;
        player.transform.localRotation = Quaternion.identity; // Reset rotation

        // Disable player control, enable bike control
        playerControlScript.enabled = false;
        bikeControlScript.enabled = true;

        Debug.Log("Riding the bike");
    }

    void Dismount()
    {
        isRiding = false;
        // Unparent player from the bike and reset control
        player.transform.SetParent(null, true);

        // Enable player control, disable bike control
        playerControlScript.enabled = true;
        bikeControlScript.enabled = false;

        Debug.Log("Dismounting from the bike");
    }
}
