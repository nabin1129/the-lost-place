using UnityEngine;

public class eventTrigger : MonoBehaviour
{
    public GameObject find;
    public GameObject find2;
    public Collider collision;


    void Start()
    {
        find.SetActive(false); // Deactivate find object at start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            find.SetActive(true);
            collision.enabled = false; // Optional: Disable collider after trigger

        }
    }
}