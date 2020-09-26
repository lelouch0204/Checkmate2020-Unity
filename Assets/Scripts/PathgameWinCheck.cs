using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathgameWinCheck : MonoBehaviour
{
    ScoreManager scoreManager;
    public GameObject ScoreManager;
    public navigatormovement navigator;
    public GameObject pathmover;

    void Start()
    {
        scoreManager = ScoreManager.GetComponent<ScoreManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Navigator"))
        {
            scoreManager.ScoreUpdater(navigator.score, "path-game", "anshal");
            Debug.Log("won");
            pathmover.SetActive(false);
        }
    }
}
