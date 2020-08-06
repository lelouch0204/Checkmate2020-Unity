using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class turner : MonoBehaviour
{
    public float rotationMin = 0.0f;
    public float rotationMax = 180.0f;
    public Slider xSlider;
    public Slider ySlider;
    public Slider zSlider;

    //[SerializeField] float currentRoation = 25.0f;

    // Use this for initialization
    void Start()
    {
        //xSlider = GameObject.Find("xSlider").GetComponent<Slider>();
       // ySlider = GameObject.Find("ySlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(xSlider.value, ySlider.value, zSlider.value);
    }
}
