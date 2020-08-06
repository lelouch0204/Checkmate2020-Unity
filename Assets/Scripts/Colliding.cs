using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliding : MonoBehaviour
{
    // Start is called before the first frame update
    public Material Blue;
    public Rigidbody rb;
    public Vector3 add;
    public float time=0, t=0;
    GameObject shooter;
    Counter script;
    public bool set = false;
    
    void Start()
    {
        shooter = GameObject.FindGameObjectWithTag("Shooter");
        script = shooter.GetComponent<Counter>();
        script.active = true;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if(time-t>3)
        {
            if (set == false)
            {
                script.active = false;
                set = true;
                script.score = 0;
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        add = collision.contacts[0].normal;
        if (collision.collider.GetComponent<Bouncer>())
        {
            if (collision.collider.GetComponent<IfBlue>().hit==false)
            {
                collision.collider.GetComponent<MeshRenderer>().material = Blue;
                t = time;
                script.score++;
                collision.collider.GetComponent<IfBlue>().hit = true;
                
            }
        }
      

       
    }
   
}
