using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToRtotate : MonoBehaviour
{
    Vector3 x;
    public bool rotate=false;
    public Transform parent;
    GameObject shooter;
    Counter script;
    // Start is called before the first frame update
    void Start()
    {
        shooter = GameObject.FindGameObjectWithTag("Shooter");
        script = shooter.GetComponent<Counter>();
        x.x = 90;
        x.y = 0;
        x.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (script.active == false)
        {
            if (rotate == true)
            {
                parent.Rotate(x);
                rotate = false;
            }
        }
    }
}
