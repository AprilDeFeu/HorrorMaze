using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isRunning = false;
    public bool isWalking = false;
    public CharacterController controller;
    public float speed = 5f;
    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButton("Fire3"))  
        {
            isRunning = true;
            speed = 8f;
        }
        else {
            isRunning = false;
            speed =5f;
        }

        if (x != 0 || z != 0) isWalking = true;
        else isWalking = false;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

    }
}
