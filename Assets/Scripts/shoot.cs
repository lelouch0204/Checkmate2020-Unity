using UnityEngine;

public class shoot : MonoBehaviour
{
    public Camera cam;
    public flip reset;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
			{
                if(hit.transform.tag == "face") 
				{
                    hit.transform.GetComponent<emotionchange>().changeface();
                }
                if (hit.transform.tag == "button" && reset.triggered)
                {
                    hit.transform.GetComponent<colourchange>().change();
                    hit.transform.GetComponent<otherflip>().changeother();
                }
                if (hit.transform.tag == "reset" && reset.triggered)
				{
                    hit.transform.GetComponent<reset>().again();
                }
                if(hit.transform.tag == "resetBlockade" && reset.triggered)
                {
                    hit.transform.GetComponent<reset>().again();
                    hit.transform.GetComponent<resetBlockade>().destroyBlokcade();
                }
                if(hit.transform.tag == "Slider")
                {
                    //Debug.Log("hi");
                    hit.transform.GetComponent<SliderController>().sliderEngaged = true;
                }
                if (hit.transform.tag == "submit")
                {
                    hit.transform.GetComponent<riddlecheck>().answercheck();
                }
                if (hit.transform.tag == "input")
                {
                    hit.transform.GetComponent<numberchange>().changenumber();
                }
            }
        }
    }
}
