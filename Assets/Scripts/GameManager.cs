using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    Highscore hScore;
    public Camera fpsCam;
    public Camera tetrisCam;
    AudioListener fpsAudio;
    AudioListener tetrisAudio;
    public Image crosshair;
    public GameObject tetrisPanel;


    // Use this for initialization
    void Start()
    {
        hScore = gameObject.GetComponent<Highscore>();
        fpsAudio = fpsCam.GetComponent<AudioListener>();
        tetrisAudio = tetrisCam.GetComponent<AudioListener>();
    }

    void Update()
    {
        if(hScore.gameOver)
        {
            SwitchToFPS();
        }
        StartFunction();
    }


    public void StartFunction()
    {
        if(tetrisCam.enabled)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                Destroy(tetrisPanel);
                this.gameObject.GetComponent<Movement>().startGame();
            }
        }
    }

    public void SwitchToFPS()
    {
        fpsAudio.enabled = true;
        fpsCam.enabled = true;
        crosshair.enabled = true;
        tetrisAudio.enabled = false;
        tetrisCam.enabled = false;
    }
}