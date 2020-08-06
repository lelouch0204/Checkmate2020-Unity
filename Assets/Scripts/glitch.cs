using UnityEngine;

public class glitch : MonoBehaviour
{
    bool triggered = false;
    void OnTriggerEnter()
    {
        if (!triggered)
        {
            triggered = true;
            Pmove.glitched = true;
        }
    }
}