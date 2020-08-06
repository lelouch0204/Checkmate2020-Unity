using UnityEngine;
using System;

public class Pmove : MonoBehaviour
{
    CharacterController cont;
    public Camera fpscam;
    public static float speed = 10;
    public static float g = 10;
    public static float jump = 5;
    Vector3 movement;
    public static bool flipped = false;
    public static bool glitched = false;

    void Start()
    {
        cont = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(flipped)
		{
            g = -15;
		}

        if (!flipped)
        {
            g = 15;
        }

        if (glitched)
        {
            x *= -1;
            z *= -1;
        }

        movement = transform.right * x + transform.forward * z;

        movement.y -= g * Time.deltaTime;

        cont.Move(movement * speed * Time.deltaTime);    
    }
}

/*
 *
 * if (Input.GetButton("Jump") && cont.isGrounded)
            {
                movement.y = jump;
            }
*/