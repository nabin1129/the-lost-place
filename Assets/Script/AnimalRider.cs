using UnityEngine;

public class HorseRider : MonoBehaviour
{
    public GameObject Horse; // Reference to the Horse GameObject
    public float rideDistance = 2f; // Distance at which the player can ride the Horse
    public float flySpeed = 5f; // Speed at which the Horse moves when riding

    private bool isRiding = false; // Tracks if the player is currently riding
    private Transform playerTransform; // Reference to the player's transform
    private Transform HorseTransform; // Reference to the Horse's transform

    private void Start()
    {
        playerTransform = transform; // Get the player's transform
        HorseTransform = Horse.transform; // Get the Horse's transform
    }

    private void Update()
    {
        // Check if the 'F' key is pressed to start or stop riding
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isRiding)
            {
                StartRiding();
            }
            else
            {
                StopRiding();
            }
        }

        if (isRiding)
        {
            // Handle movement while riding
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            HorseTransform.Translate(moveDirection * flySpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isRiding && other.CompareTag("Horse"))
        {
            StartRiding();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isRiding && other.CompareTag("Horse"))
        {
            StopRiding();
        }
    }

    private void StartRiding()
    {
        // Ensure the Horse is active and not hidden
        if (!Horse.activeInHierarchy)
        {
            Debug.LogWarning("Horse is not active, reactivating...");
            Horse.SetActive(true);
        }

        // Parent the player to the Horse and set the correct position for riding
        playerTransform.SetParent(HorseTransform);
        playerTransform.localPosition = new Vector3(0f, 0.75f, 0f); // Adjust position for riding
        playerTransform.localRotation = Quaternion.identity; // Reset rotation for correct alignment

        isRiding = true; // Update riding status

        Debug.Log("Started riding.");
    }

    private void StopRiding()
    {
        // Unparent the player from the Horse
        playerTransform.SetParent(null);

        // Optionally, adjust the player's position after dismounting
        playerTransform.position += Vector3.right * 1f; // Shift slightly to the right upon dismounting

        isRiding = false; // Update riding status

        Debug.Log("Stopped riding.");
    }
}
