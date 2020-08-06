using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navigatormovement : MonoBehaviour
{
    public int x=0, z=0,score=120;
    public int speed = 5;
    public bool canmove = false;
    // Start is called before the first frame update
    public CharacterController c;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("u"))
        {
            //Debug.Log("u");
            x = 1;
        }
        else if (Input.GetKey("j"))
        {
            x = -1;
        }
        else
        {
            x = 0;
        }
        
        if (Input.GetKey("h"))
        {
            z = 1;
        }
        else if (Input.GetKey("k"))
        {
            z = -1;
        }
        else
        {
            z = 0;
        }
        Vector3 move = transform.right * x + transform.forward * z;
        if (canmove == true)
        {
            c.Move(move * speed * Time.deltaTime);
        }
        /*if(transform.position.z>3)
        {
            Debug.Log("won");
            scoreManager.ScoreUpdater(100);
        }*/
        if(score<20)
        {
            score = 10;
        }
    }
    
}
