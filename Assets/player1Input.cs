using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Input : MonoBehaviour
{
    [Range(0, 1)]
    public float deadZone = 0.2f;
    public string horizontalAxisName = "Joy2Horz";
    public string verticalAxisName = "Joy2Vert";
    public float speed = 3;

    private void Update()
    {
        Vector3 flatForward = Camera.main.transform.forward;
        flatForward.y = 0;
        flatForward.Normalize();

        Vector3 flatRight = Camera.main.transform.right;
        flatRight.y = 0;
        flatRight.Normalize();

        if (Mathf.Abs(Input.GetAxis(horizontalAxisName)) > deadZone)
            gameObject.transform.Translate(flatRight * Input.GetAxis(horizontalAxisName) * Time.deltaTime * speed);
        if (Mathf.Abs(Input.GetAxis(verticalAxisName)) > deadZone)
            gameObject.transform.Translate(flatForward * -Input.GetAxis(verticalAxisName) * Time.deltaTime * speed);
    }
}
