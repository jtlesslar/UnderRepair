using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject theObject; //the object to pick up
    protected bool canPickUp  = false; //turns true when the player is close enough to the object
    protected Collider thePlayer; //player object colliding
    
    public void Start()
    {

    }
    public void Update()
    {
        if (Input.GetKey("joystick button 0") && canPickUp)
        {
            theObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void  OnTriggerEnter(Collider info)
    {
        if (info.tag == "Player")
        {
            canPickUp = true;
            thePlayer = info;
        }
    }

    public void OnTriggerExit(Collider info)
    {
        if (info.tag == "Player")
        {
            canPickUp = false;
            thePlayer = null;
        }
    }
}
