using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public GameObject player;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 15f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    if (IsLookingAtObject(collider))
                    {
                        npcInteractable.InteractStatus = true;
                    }
                }
            }
        }
    }
    bool IsLookingAtObject(Collider collider)
    {
        Vector3 direction = collider.transform.position - player.transform.position;
        float angle = Vector3.Angle(player.transform.forward, direction);
        return angle < 20f;
    }
    public NPCInteractable GetInteractableObj()
    {
        float interactRange = 15f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                if (IsLookingAtObject(collider))
                {
                    return npcInteractable;
                }
            }
        }
        return null;
    }
}