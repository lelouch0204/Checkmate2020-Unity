using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfBlue : MonoBehaviour
{
    public Material white;
    public bool hit=false;
    public GameObject shooter;
    Shoot scrip;
    
    
    // Start is called before the first frame update
    void Start()
    {
        shooter = GameObject.FindGameObjectWithTag("Shooter");
        scrip = shooter.GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
       if(scrip.shotted==true)
        {
            hit = false;
            gameObject.GetComponent<MeshRenderer>().material = white;
        }
    }
}
