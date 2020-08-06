using UnityEngine;
using System;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;
using UnityStandardAssets.Characters.FirstPerson;

public class flip : MonoBehaviour
{
    public bool triggered = false;
    public GameObject blockade;
    public GameObject outsideFlipper;
    void Start()
    {
        blockade.SetActive(false);
        outsideFlipper.SetActive(false);
    }
    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            Debug.Log("up");
            triggered = true;
            blockade.SetActive(true);
            outsideFlipper.SetActive(true);
        }
    }
}
