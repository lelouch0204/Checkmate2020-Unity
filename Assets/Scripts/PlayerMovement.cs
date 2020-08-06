using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController c;
    public float speed ;
    public Vector3 velocity;
    public float g = -9.8f;
    bool grounded;
    public Transform groundcheck;
    public float groundDist = 0.4f;
    public LayerMask groundMask;
    public float height;

    

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundcheck.position, groundDist, groundMask);
        if(grounded&&velocity.y<0)
        {
            velocity.y = -2f;
        }
        
        if(Input.GetButtonDown("Jump")&&grounded)
        {
            velocity.y = Mathf.Sqrt(height * -2f * g);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward *z;
        c.Move(move * speed * Time.deltaTime);
        
          velocity.y += g * Time.deltaTime; 
        

        c.Move(velocity * Time.deltaTime);
    }
}
