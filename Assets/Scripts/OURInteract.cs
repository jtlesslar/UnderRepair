using System;
using UnityEngine;

public class OURInteract : Interactable
{

    public override void Interact()
    {
        base.Interact();

        Repair();
    }

    void Repair()
    {
        Debug.Log("Repairing OUR");

    }
}

