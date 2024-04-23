using UnityEngine;

public class FlyingCar : MonoBehaviour
{
    // Public fields to adjust in the Inspector
    public float speed = 10f; // Forward/backward speed
    public float turnSpeed = 50f; // Rotation speed
    public float ascendSpeed = 5f; // Speed for ascending
    public float descendSpeed = 5f; // Speed for descending
    public float hoverHeight = 2f; // Desired height above the ground

    // Private fields to manage internal states
    private Rigidbody rb; // Rigidbody component for physics-based movement

    void Start()
    {
        // Initialize the Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing!");
        }
    }

    void Update()
    {
        // Handle movement input
        float vertical = Input.GetAxis("Vertical"); // W/S or up/down arrow for forward/backward
        float horizontal = Input.GetAxis("Horizontal"); // A/D or left/right arrow for turning
        bool ascend = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift); // LeftShift to ascend
        bool descend = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl); // Ctrl keys to descend

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

        // Control hovering to maintain a minimum height
        Hover();
    }

    void Hover()
    {
        // Raycast down to maintain hover height
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            float heightDifference = hoverHeight - hit.distance;
            rb.AddForce(Vector3.up * heightDifference * ascendSpeed, ForceMode.Force);
        }
    }
}
