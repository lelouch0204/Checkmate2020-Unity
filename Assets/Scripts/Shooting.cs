using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {

                Shoot shoot = hit.transform.GetComponent<Shoot>();
                if (shoot != null)
                { shoot.fire = true; }
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {

                ToRtotate torotate= hit.transform.GetComponent<ToRtotate>();
                if (torotate != null)
                { torotate.rotate = true; }
                
            }
        }
    }
}
