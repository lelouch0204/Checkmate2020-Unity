using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform barrelend;
    GameObject shot;
    public bool fire=false;
    public Counter script;
    public bool shotted=false;
    public int score = 110;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (script.active == false)
        {
            if (fire == true)
            {
                Rigidbody rb;
                shot = Instantiate(bullet, barrelend.position, Quaternion.identity);
                if (score > 10)
                {
                    score -= 10;
                }
                rb = shot.GetComponent<Rigidbody>();
                rb.AddForce(5* barrelend.up, ForceMode.Impulse);
                fire = false;
                script.active = true;
                shotted = true;
                Invoke("change", 0.3f);
            }
        }
    }
    public void change()
    {
        shotted = false;
    }
}
