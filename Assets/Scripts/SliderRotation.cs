using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRotation : MonoBehaviour
{
    public GameObject mirror;
    public Slider slider;

    private float previousValue;
    // Start is called before the first frame update
    void Start()
    {
        this.slider.onValueChanged.AddListener(this.OnSliderChanged);
        this.previousValue = this.slider.value;
    }

    void OnSliderChanged(float value)
    {
        float delta = value - this.previousValue;
        this.mirror.transform.Rotate(Vector3.right * 360 * delta);
        this.previousValue = value;
    }
}
