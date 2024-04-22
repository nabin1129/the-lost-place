using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMovement : MonoBehaviour
{
    public float speed = 10f; // The speed at which the bike moves
    public float turnSpeed = 50f; // The speed at which the bike turns
    public float jumpForce = 300f; // The force applied when jumping (if needed)
    public Rigidbody rb; // The Rigidbody component on the bike

    private bool isGrounded = true; // To check if the bike is on the ground

    void Start()
    {
        // Ensure the Rigidbody is assigned
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        // Move the bike forward and backward
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rb.AddForce(transform.forward * move, ForceMode.VelocityChange);

        // Turn the bike left and right
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);

        // Example: Add jump functionality (optional)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // After jumping, bike is no longer grounded
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // If the bike collides with something, it's grounded again
        isGrounded = true;
    }
}