using StarterAssets;
using UnityEngine;

public class FlyingCar : MonoBehaviour
{
    // Public fields for movement and camera control
    public float speed = 10f; // Forward/backward speed
    public float turnSpeed = 50f; // Rotation speed
    public float ascendSpeed = 5f; // Speed for ascending
    public float descendSpeed = 5f; // Speed for descending
    public float brakeForce = 100f; // Force applied for braking
    public float stopThreshold = 0.1f; // Minimum speed to consider the vehicle stopped
    
    

    // Private fields
    private Rigidbody rb; // Rigidbody component for physics-based movement
   


    void Start()
    {
       
        // Initialize the Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing!");
        }

        // Ensure only one camera is active at start
        

        //PersonController.enabled = true;
        // Ensure car controls are disabled at start
        //if (carControls != null) carControls.enabled = !PersonController.isActiveAndEnabled;

    }

    void Update()
    {
        

        // Check for camera switching key
        
            // Handle movement input
            float vertical = Input.GetAxis("Vertical"); // W/S or up/down arrow for forward/backward
            float horizontal = Input.GetAxis("Horizontal"); // A/D or left/right arrow for turning
            bool ascend = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift); // Shift to ascend
            bool descend = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl); // Ctrl to descend
            bool brake = Input.GetKey(KeyCode.Space); // Spacebar for braking

            // Control forward/backward movement
            Vector3 forward = transform.forward * vertical * speed;
            rb.AddForce(forward, ForceMode.Force);

            // Control turning
            float turn = horizontal * turnSpeed * Time.deltaTime;
            transform.Rotate(0, turn, 0);

            // Control ascending/descending
            if (ascend)
            {
                rb.AddForce(Vector3.up * ascendSpeed, ForceMode.Force);
            }
            else if (descend)
            {
                rb.AddForce(Vector3.down * descendSpeed, ForceMode.Force);
            }
        if (brake)
        {
            ApplyBraking();
        }
    }

    void ApplyBraking()
    {
        // Apply a braking force in the opposite direction of travel
        rb.AddForce(-transform.forward * brakeForce, ForceMode.Force);

        // If the vehicle's speed is below the threshold, set its velocity to zero
        if (rb.velocity.magnitude < stopThreshold)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero; // Optional, to stop spinning
        }
    }
}

    

