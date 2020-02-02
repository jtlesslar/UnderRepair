using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerInput : MonoBehaviour
{
    public string horizontalAxisName = "Joy1Horz";
    public string verticalAxisName = "Joy1Vert";
    public string joystickButton0 = "joystick 1 button 0";
    public string joystickButton1 = "joystick 1 button 1";
    public float speed = 1;
    public float acceleration = 1;
    public float rotationSpeed = 1;
    public Rigidbody rBody;

    public float nextStunnable = 0f;
    float nextStunnableDelay = 1.5f;

    bool stunned = false;
    protected MaterialPickup heldObj;

    private void Update()
    {
        if (!stunned)
        {
            if (rBody == null)
                rBody = GetComponent<Rigidbody>();

            //Get camera forward
            Vector3 flatForward = Camera.main.transform.forward;
            flatForward.y = 0;
            flatForward.Normalize();

            //Get camera right
            Vector3 flatRight = Camera.main.transform.right;
            flatRight.y = 0;
            flatRight.Normalize();

            //Start with no velocity
            Vector3 desiredVelocity = Vector3.zero;
            //Add the right/left amount
            desiredVelocity += flatRight * Input.GetAxis(horizontalAxisName);
            //Add the forward/back amount
            desiredVelocity += flatForward * -Input.GetAxis(verticalAxisName);

            if (desiredVelocity.magnitude > 0.1f)
            {
                //Normalise velocity
                desiredVelocity = desiredVelocity.normalized * speed;
                //Make sure you're using gravity
                desiredVelocity.y = rBody.velocity.y;

                //Blend to desired force
                rBody.velocity = Vector3.Lerp(rBody.velocity, desiredVelocity, Time.deltaTime * acceleration);
            }

            desiredVelocity = rBody.velocity;
            desiredVelocity.y = 0;
            if (desiredVelocity.magnitude > 0.1f)
            {
                //Look at direction of rotation
                rBody.MoveRotation(Quaternion.Slerp(rBody.rotation, Quaternion.LookRotation(desiredVelocity, Vector3.up), Time.deltaTime * rotationSpeed));
            }

            if (Input.GetKey(joystickButton0))
            {
                if (heldObj && heldObj.IsHeld())
                {
                    heldObj.Drop();
                }

                Vector3 startPos = transform.position + new Vector3(0, -0.6f, 0);

                Vector3 endPosition = transform.forward;

                Debug.DrawRay(startPos, transform.forward, Color.blue);

                RaycastHit hitInfo;

                if (Physics.Raycast(startPos, transform.forward, out hitInfo, 2f))
                {
                    heldObj = hitInfo.collider.gameObject.GetComponent<MaterialPickup>();

                    Interactable inter = hitInfo.collider.gameObject.GetComponent<Interactable>();

                    if (inter)
                    {
                        inter.Interact(gameObject);
                    }
                }
            }

            if (Input.GetKey(joystickButton1))
            {
                Vector3 startPos = transform.position + new Vector3(0, 0f, 0);

                Vector3 endPosition = transform.forward;

                Debug.DrawRay(startPos, transform.forward, Color.red);

                RaycastHit hitInfo;

                if (Physics.Raycast(startPos, transform.forward, out hitInfo, 1f))
                {
                    PlayerInput playerInput = hitInfo.collider.gameObject.GetComponent<PlayerInput>();
                    Rigidbody rigidbody = hitInfo.collider.gameObject.GetComponent<Rigidbody>();

                    if (rigidbody && playerInput && (playerInput.nextStunnable < Time.time))
                    {
                        rigidbody.AddForce((transform.forward * 1000 + new Vector3(0, 1000, 0)), ForceMode.Impulse);

                        playerInput.Stun();
                    }
                }
            }
        }
    }

    public void Stun()
    {
        if (nextStunnable < Time.time)
        {
            GetComponent<AudioSource>().Play();

            stunned = true;
            nextStunnable = Time.time + nextStunnableDelay;
            Invoke("UnStun", nextStunnableDelay - 0.1f);
        }
    }

    public void UnStun()
    {
        stunned = false;
    }

}