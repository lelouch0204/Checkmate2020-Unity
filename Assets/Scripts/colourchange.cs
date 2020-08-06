using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourchange : MonoBehaviour
{
    public bool flip = false;
    Animation anim;
    public void change()
    {
        anim = GetComponent<Animation>();
        if (!flip)
        {
            flip = true;
            anim["buttonflip"].time = 0;
            anim["buttonflip"].speed = 1;
            anim.Play("buttonflip");
        }
        else
		{
            flip = false;
            anim["buttonflip"].time = anim["buttonflip"].length;
            anim["buttonflip"].speed = -1;
            anim.Play("buttonflip");
        }
    }
}
