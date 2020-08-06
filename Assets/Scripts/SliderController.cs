using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    shoot shot;
    public Slider slider;
    public bool sliderEngaged = false;
    public float scale = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sliderEngaged)
        {
            slider.Select();
            slider.value -= Input.mouseScrollDelta.y * scale;
            if(Input.GetButtonDown("Fire1") && sliderEngaged)
            {
                sliderEngaged = false;
            }
        }
    }
}
