using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject intText;
    public bool interactable, toggle;
    public Animator doorAnim;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                toggle = !toggle;
                if (toggle == true)
                {
                    doorAnim.ResetTrigger("close");
                    doorAnim.SetTrigger("open"); // Added closing parenthesis here
                }
                if (toggle == false)
                {
                    doorAnim.ResetTrigger("open");
                    doorAnim.SetTrigger("close"); // Added closing parenthesis here
                }
                intText.SetActive(false);
                interactable = true;
            }
        }
    }
}