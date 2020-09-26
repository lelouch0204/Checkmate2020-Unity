using UnityEngine;

public class resetBlockade : MonoBehaviour
{
    public GameObject ScoreManager;
    ScoreManager scoreManager;
    public GameObject blockade;
    public flip reset;
    public GameObject flipper;
    public GameObject outsideFlipper;

    void Start()
    {
        scoreManager = ScoreManager.GetComponent<ScoreManager>();   
    }

    public void destroyBlokcade()
    {
        scoreManager.ScoreUpdater(-20, "checkers", "anshal");
        blockade.SetActive(false);
        reset.triggered = false;
        flipper.SetActive(false);
        outsideFlipper.SetActive(true);
    }
}
