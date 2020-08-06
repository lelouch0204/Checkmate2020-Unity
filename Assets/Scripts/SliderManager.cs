﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{

    [SerializeField]
    GameObject sliderObj;

    [SerializeField]
    GameObject cameraRig;

    GameObject sliderObjParent;
    Slider slider;

    float adjacentDistance;

    float width;
    float scaleX;
    float parentScaleX;
    float oppositeDistance;

    float radTan;
    float angle;

    float defaultRotateY;
    public float DefaultRotateY
    {
        set { defaultRotateY = value; }
    }
    float nowRotateY;

    float magValue;
    float defaultValue;
    float resetValue;

    bool isSlider = false;
    public bool IsSlider
    {
        set { isSlider = value; }
    }

    void Start()
    {

        sliderObjParent = sliderObj.transform.parent.gameObject;
        slider = sliderObj.GetComponent<Slider>();

        isSlider = false;

        adjacentDistance = Vector3.Distance(cameraRig.transform.position, sliderObj.transform.position);

        width = sliderObj.GetComponent<RectTransform>().sizeDelta.x;
        scaleX = sliderObj.GetComponent<RectTransform>().localScale.x;
        parentScaleX = sliderObjParent.GetComponent<RectTransform>().localScale.x;
        oppositeDistance = width * scaleX * parentScaleX;

        radTan = oppositeDistance / adjacentDistance;
        //Debug.Log("atanRad = " + Mathf.Atan(radTan));
        //Debug.Log("atanDeg = " + (Mathf.Atan(radTan) * Mathf.Rad2Deg));
        angle = Mathf.Atan(radTan) * Mathf.Rad2Deg;

        magValue = (slider.maxValue - slider.minValue);
        angle *= magValue;
        defaultValue = slider.value;

    }

    void Update()
    {

        if (isSlider && Input.GetMouseButton(0))
        {

            nowRotateY = cameraRig.transform.rotation.eulerAngles.y;
            nowRotateY = (nowRotateY >= 180f) ? (nowRotateY - 360f) : nowRotateY;
            resetValue = (((nowRotateY - defaultRotateY) * (magValue / angle)) * magValue) + defaultValue;

            if (resetValue < slider.minValue)
            {
                slider.value = slider.minValue;
            }
            else if (resetValue > slider.maxValue)
            {
                slider.value = slider.maxValue;
            }
            else
            {
                slider.value = resetValue;
            }
        }
        else
        {
            isSlider = false;
        }

    }
}