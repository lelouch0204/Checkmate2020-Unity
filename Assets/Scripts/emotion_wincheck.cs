using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emotion_wincheck : MonoBehaviour
{
    public GameObject[] faces; //NSEW order
    int check = 0;
    Animation anim;
    public GameObject ScoreManager;
    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = ScoreManager.GetComponent<ScoreManager>();
    }

    void Update()
    {
        if (check == 0 && faces[0].GetComponent<emotionchange>().emotion == 1 && faces[1].GetComponent<emotionchange>().emotion == 1 && faces[2].GetComponent<emotionchange>().emotion == 0 && faces[3].GetComponent<emotionchange>().emotion == 2)
        {
            win();
        }
    }

    void win()
	{
        if (check == 0)
		{
            check = 1;
            Debug.Log("Win");
            scoreManager.ScoreUpdater(100);
            for (int i = 0; i < 4; i++)
            {
                faces[i].tag = "blank";
            }
            Invoke("reversefaces", 2);
        }

	}
    void reversefaces()
	{
        anim = faces[0].transform.parent.GetChild(3).GetComponent<Animation>();
        anim["maskswap"].time = anim["maskswap"].length;
        anim["maskswap"].speed = -1;
        anim.Play("maskswap");

        anim = faces[1].transform.parent.GetChild(3).GetComponent<Animation>();
        anim["maskswap"].time = anim["maskswap"].length;
        anim["maskswap"].speed = -1;
        anim.Play("maskswap");

        anim = faces[2].transform.parent.GetChild(2).GetComponent<Animation>();
        anim["maskswap"].time = anim["maskswap"].length;
        anim["maskswap"].speed = -1;
        anim.Play("maskswap");

        anim = faces[3].transform.parent.GetChild(1).GetComponent<Animation>();
        anim["maskswap"].time = anim["maskswap"].length;
        anim["maskswap"].speed = -1;
        anim.Play("maskswap");

        for (int i = 0; i < 4; i++)
        {
            Destroy(faces[i]);
        }
    }
}
