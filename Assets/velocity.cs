﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocity : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 vel;
    public Rigidbody rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vel= rb.velocity;
    }
}
