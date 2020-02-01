using System;
using UnityEngine;

public class MaterialPickup : Interactable
{  

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picking up material");

    }
}

