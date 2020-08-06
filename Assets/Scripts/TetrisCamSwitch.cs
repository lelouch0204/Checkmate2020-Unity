using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TetrisCamSwitch : MonoBehaviour
{
    public Camera fpsCam;
    public Camera tetrisCam;
    AudioListener fpsAudio;
    AudioListener tetrisAudio;
    public Image crosshair;
    public GameObject tetrisPanel;
    // Start is called before the first frame update
    void Start()
    {
        fpsAudio = fpsCam.GetComponent<AudioListener>();
        tetrisAudio = tetrisCam.GetComponent<AudioListener>();
        fpsAudio.enabled = true;
        fpsCam.enabled = true;
        crosshair.enabled = true;
        tetrisAudio.enabled = false;
        tetrisCam.enabled = false;
        tetrisPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            fpsCam.enabled = false;
            fpsAudio.enabled = false;
            crosshair.enabled = false;
            tetrisCam.enabled = true;
            tetrisAudio.enabled = true;
            if(tetrisPanel != null)
            {
                tetrisPanel.SetActive(true);
            }
        }
    }
}
