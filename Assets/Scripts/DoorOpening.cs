using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    private bool isOpen = false;
    public GameObject floatingText;
    bool isCreated = false;
    public Transform door;
    bool entered = false;
    public float openSpeed = 120;
    Animator anim;

    private void Start()
    {
        anim = door.GetComponent<Animator>();
    }

    private void Update()
    {
        if(entered)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(!isOpen)
                {
                    //door.transform.Translate(Vector3.up * Time.deltaTime * openSpeed);
                    isOpen = true;
                    anim.SetBool("openDoor", true);
                    anim.SetBool("closeDoor", false);
                }
                else
                {
                    //door.transform.Translate(Vector3.down * Time.deltaTime * openSpeed);
                    isOpen = false;
                    anim.SetBool("openDoor", false);
                    anim.SetBool("closeDoor", true);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            entered = true;
            /*while (!isCreated)
            {
                Instantiate(floatingText, transform.position, Quaternion.identity);
                isCreated = true;
            }*/

        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }*/
}
