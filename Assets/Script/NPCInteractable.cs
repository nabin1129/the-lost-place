using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{

    private bool interactStatus;
    public bool InteractStatus
    {
        get { return interactStatus; }
        set { interactStatus = value; }
    }
}