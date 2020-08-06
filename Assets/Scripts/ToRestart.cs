using UnityEngine;

public class ToRestart : MonoBehaviour
{
    public Material gold, red, blue;

    public int death = 0;
    private GameObject a;
    private float dist;
    private GameObject b, d;
    private Show c;
    public int timetosee;
    private navigatormovement script;

    private void Start()
    {
        a = GameObject.FindGameObjectWithTag("Navigator");
        b = GameObject.FindGameObjectWithTag("Button");
        d = GameObject.FindGameObjectWithTag("Restarter");
        c = b.GetComponent<Show>();
        script = a.transform.GetComponent<navigatormovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (death == 2 && c.abletosee == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = gold;
            Invoke("changetored", timetosee);
        }
        if (death == 1 && c.abletosee == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = gold;
            Invoke("changetoblue", timetosee);
        }

        dist = Vector3.Distance(a.transform.position, transform.position);

        if (Mathf.Abs(a.transform.position.x - transform.position.x) < 0.24 && (Mathf.Abs(a.transform.position.z - transform.position.z) < 0.24))
        {
            if (death == 0)
            {
                a.transform.position = d.transform.position;
                script.score -= 10;
            }
        }
    }

    private void changetored()
    {
        gameObject.GetComponent<MeshRenderer>().material = red;
    }

    private void changetoblue()
    {
        gameObject.GetComponent<MeshRenderer>().material = blue;
    }
}