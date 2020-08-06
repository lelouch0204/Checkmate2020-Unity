using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public bool active = false;
    public int score = 0;
    bool won = false;
    public int finalScore;
    public Shoot script;
    ScoreManager scoreManager;
    public GameObject ScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = ScoreManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(score==100)
        {
            if(won==false)
            {
                Debug.Log("you won");
                won = true;
                finalScore = script.score;
                scoreManager.ScoreUpdater(finalScore);
            }
        }
    }
}
