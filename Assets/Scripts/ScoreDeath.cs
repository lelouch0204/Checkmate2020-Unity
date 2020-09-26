using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public float t = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
    }
}