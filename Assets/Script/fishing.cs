using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishing : MonoBehaviour
{
    public float castDistance = 5f;
    public float fishingCooldown = 2f;
    public LayerMask waterLayer;
    public GameObject caughtFishPrefab;

    private bool isFishing = false;
    private float lastCastTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time > lastCastTime + fishingCooldown)
        {
            CastLine();
        }

        if (isFishing && Input.GetMouseButtonDown(0))
        {
            ReelIn();
        }
    }

    void CastLine()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, castDistance, waterLayer))
        {
            Debug.DrawLine(transform.position, hit.point, Color.blue, 2f);
            Debug.Log("You cast your line into the water.");

            // Start fishing
            isFishing = true;
            lastCastTime = Time.time;
        }
        else
        {
            Debug.Log("There's no water to fish in front of you.");
        }
    }

    void ReelIn()
    {
        // Simulate catching a fish (can be more complex in a real game)
        Debug.Log("You caught a fish!");

        // Instantiate a fish prefab at the caught position
        Instantiate(caughtFishPrefab, transform.position, Quaternion.identity);

        // Stop fishing
        isFishing = false;
    }
}