using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutSideReset : MonoBehaviour
{
    public flip reset;
    public GameObject flipper;

    void OnTriggerEnter(Collider other)
    {
        if(!reset.triggered && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("test");
            reset.triggered = true;
            flipper.SetActive(true);
        }
    }
}
