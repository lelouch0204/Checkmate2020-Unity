using UnityEngine;

public class emotionchange : MonoBehaviour
{
    public GameObject mask;
    public GameObject hmask;
    public GameObject smask;
    public int emotion;
    Animation anim1;
    Animation anim2;
    Animation anim3;
    Vector3 pos;
    public void changeface()
    {
        anim1 = mask.GetComponent<Animation>();
        anim2 = hmask.GetComponent<Animation>();
        anim3 = smask.GetComponent<Animation>();
        Debug.Log(emotion);
        emotion++;
        if (emotion == 1)
        {
            anim3["maskswap"].time = anim3["maskswap"].length;
            anim3["maskswap"].speed = -1;
            anim3.Play("maskswap");
            anim1["maskswap"].time = 0;
            anim1["maskswap"].speed = 1;
            anim1.Play("maskswap");
        }
        if (emotion == 2)
		{
            anim1["maskswap"].time = anim1["maskswap"].length;
            anim1["maskswap"].speed = -1;
            anim1.Play("maskswap");
            anim2["maskswap"].time = 0;
            anim2["maskswap"].speed = 1;
            anim2.Play("maskswap");
        }
        if (emotion == 3)
		{
            
            emotion = 0;
            anim2["maskswap"].time = anim2["maskswap"].length;
            anim2["maskswap"].speed = -1;
            anim2.Play("maskswap");
            anim3["maskswap"].time = 0;
            anim3["maskswap"].speed = 1;
            anim3.Play("maskswap");
        }

	}
}
