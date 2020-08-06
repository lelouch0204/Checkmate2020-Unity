using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    GameObject g1;
    public void again()
    {
        for (int i = 0; i < 25; i++)
        {
            string nname = "Button (";
            nname = nname + i.ToString() + ")";
            g1 = GameObject.Find(nname);
            if (g1.GetComponent<colourchange>().flip)
            {
                g1.GetComponent<colourchange>().change();
            }
        }
    }
}
