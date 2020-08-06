using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TOsee : MonoBehaviour
{
    Show show;
    GameObject a,d;
    public navigatormovement script;

    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.FindGameObjectWithTag("Navigator");
        d = GameObject.FindGameObjectWithTag("Restarter");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                show = hit.transform.GetComponent<Show>();
                if(show!=null)
                {
                    show.abletosee = true;
                    script.canmove = false;
                    script.score = script.score - 2;
                    a.transform.position = d.transform.position;
                    Invoke("Change", 2);
                    if (show.score != 0)
                    {
                        show.score = show.score - 40;
                    }
                   // marks.text = show.score.ToString();
                }
            }
        }
    }

    public void Change()
    {
        show.abletosee = false;
        Invoke("canmove", 1);
    }
    public void canmove()
    {
        script.canmove = true;
    }

}
