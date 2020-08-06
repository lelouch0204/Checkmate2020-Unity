using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    int up1, right, up2, left, up3;
    public GameObject cube;
    GameObject stored;
    public Material Blue,gold;
    Vector3 a;
    public int side;
    public GameObject start;
    // Start is called before the first frame update
 void Start()
    {
     
        up1 = 2 * Random.Range(1, 6);
        right = Random.Range(1, 7); 
        up2 = 2 * Random.Range(2, 5);
        up3 = 20 - up1 - up2;
        left = 2 * Random.Range(1, 2 + right);
        right = right * 2;
       
        for (int i=0;i<side;)
        {
           

            for (int j = 0; j < side; )
            {
                a.x = i*(0.2554f);
                a.y = 1;
                a.z = j*(0.2554f);
                stored=Instantiate(cube, a+start.transform.position, Quaternion.identity);
               if ((i + j) % 4 == 0)
               {
                    stored.GetComponent<MeshRenderer>().material = Blue;
               }
               if(i==2&&j<=up1)
               {
                    if ((i + j) % 4 == 0)
                    { stored.GetComponent<ToRestart>().death = 1; }
                    else
                    { stored.GetComponent<ToRestart>().death = 2; }

               }
                if (j==up1&&i>=2&&i<=(2+right))
                {
                    if ((i + j) % 4 == 0)
                    { stored.GetComponent<ToRestart>().death = 1; }
                    else
                    { stored.GetComponent<ToRestart>().death = 2; }

                }
                if (i ==(2+right)&&j>=up1&&j<=(up1+up2))
                {
                    if ((i + j) % 4 == 0)
                    { stored.GetComponent<ToRestart>().death = 1; }
                    else
                    { stored.GetComponent<ToRestart>().death = 2; }

                }
               if (j==(up1+up2)&&i<=2+right&&i>=2+right-left)
                {
                    if ((i + j) % 4 == 0)
                    { stored.GetComponent<ToRestart>().death = 1; }
                    else
                    { stored.GetComponent<ToRestart>().death = 2; }

                }
                if (i == 2+right-left&&j>=(up1+up2))
                {
                    if ((i + j) % 4 == 0)
                    { stored.GetComponent<ToRestart>().death = 1; }
                    else
                    { stored.GetComponent<ToRestart>().death = 2; }

                }
               
                j = j + 2;
            }
            i = i + 2;

        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
