using UnityEngine;

public class wincheck : MonoBehaviour
{
    bool win = false;
    GameObject g1;
    Animation anim;
    public GameObject ScoreManager;
    ScoreManager scoreManager;

    void Start()
	{
        anim = GameObject.Find("FPSController").GetComponent<Animation>();
        scoreManager = ScoreManager.GetComponent<ScoreManager>();
    }

    void Update()
    {
        int j = 0;
        for (int i = 0; i < 25; i++)
        {
            string nname = "Button (";
            nname = nname + i.ToString() + ")";
            g1 = GameObject.Find(nname);
            if (g1.GetComponent<colourchange>().flip)
            {
                j++;
            }
        }
        win = j == 25 ? true : false;
        if (win)
        {
            Debug.Log("You won");
            FindObjectOfType<reset>().again();
            Invoke("Win",5);
        }
    }
    void Win()
    {
        scoreManager.ScoreUpdater(100, "checkers", "anshal");
        anim["flip"].time = anim["flip"].length;
        anim["flip"].speed = -1;
        anim.Play("flip");
        Destroy(GameObject.Find("reset block"));
        Destroy(GameObject.Find("reset blockade"));
        Destroy(GameObject.Find("Flipgame Block"));
        Destroy(GameObject.Find("wall"));
        Destroy(gameObject);
    }
}
