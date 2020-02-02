using System;
using UnityEngine;

public class MaterialPickup : Interactable
{
    private bool isHeld = false;
    private Transform origParent;

    public override void Interact(GameObject player)
    {
        base.Interact(player);

        if (isHeld)
            Drop();
        else
            Pickup(player);
    }

    void Pickup(GameObject player)
    {
        Debug.Log("Picking up material");
        origParent = transform.parent;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Rigidbody>().detectCollisions = false;
        transform.position = player.transform.position + player.transform.forward;
        transform.parent = player.transform;
        isHeld = true;
        gameObject.tag = "Player";
    }

    public void Drop()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().detectCollisions = true;
        transform.parent = origParent.transform;
        isHeld = false;
        gameObject.tag = "Material";
    }

    public bool IsHeld()
    {
        return isHeld;
    }
}

