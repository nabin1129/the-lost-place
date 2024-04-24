using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private List<GameObject> Children = new List<GameObject>();
    private NPCInteractable myInteract;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Information")
            {
                Children.Add(child.gameObject);
            }
        }
        myInteract = GetComponent<NPCInteractable>();
        if (myInteract == null)
        {
            Debug.Log("No GOInteraction attached to this object.");
        }
        // Default children to invisible.
        foreach (GameObject child in Children)
        {
            child.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (myInteract.InteractStatus == true)
        {
            foreach (GameObject child in Children)
            {
                if (child.activeSelf)
                {
                    child.SetActive(false);
                }
                else
                {
                    child.SetActive(true);
                }
            }
            myInteract.InteractStatus = false;
        }
    }
}