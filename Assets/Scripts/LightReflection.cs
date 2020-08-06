using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightReflection : MonoBehaviour
{
    public int reflections;
    public int maxLength;

    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;
    private bool wonGame = false;
    private bool sentRequest = false;

    ScoreManager scoreManager;
    public GameObject ScoreManager;

    private void Awake()
    {
        wonGame = false;
        sentRequest = false;
        lineRenderer = GetComponent<LineRenderer>();
        scoreManager = ScoreManager.GetComponent<ScoreManager>();
    }

    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        float remainingLength = maxLength;

        for(int i=0; i < reflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                if (hit.collider.tag != "Mirror" && hit.collider.tag != "End" && i != (reflections-1))
                {
                    //Debug.Log("break");
                    break;
                }                    
                else if (hit.collider.tag == "End" && i == (reflections - 1) && !wonGame)
                {
                    //Debug.Log("Victory");
                    wonGame = true;                    
                    break;
                }
            }

            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }
        }

        if (wonGame && !sentRequest)
        {
            //Debug.Log("Victory");
            scoreManager.ScoreUpdater(100);
            sentRequest = true;
        }
    }
}
