using UnityEngine;

public class otherflip : MonoBehaviour
{
    
    string findbase = "Button (",find,number;
    int x;
    GameObject[] buttons;
    void Start()
	{
        number = gameObject.name[8].ToString();
        if (gameObject.name[9] != ')')
        {
            number += gameObject.name[9].ToString();
        }
        x = int.Parse(number);

        if ((x>5 && x<9) || (x > 10 && x < 14) || (x > 15 && x < 19))
        {
            buttons = new GameObject[4];
            x -= 1;
            find = findbase + x.ToString() + ")";
            buttons[0] = GameObject.Find(find);
            x += 2;
            find = findbase + x.ToString() + ")";
            buttons[1] = GameObject.Find(find);
            x -= 6;
            find = findbase + x.ToString() + ")";
            buttons[2] = GameObject.Find(find);
            x += 10;
            find = findbase + x.ToString() + ")";
            buttons[3] = GameObject.Find(find);
        }

        else if (x < 4 && x > 0)
        {
            buttons = new GameObject[3];
            x -= 1;
            find = findbase + x.ToString() + ")";
            buttons[0] = GameObject.Find(find);
            x += 2;
            find = findbase + x.ToString() + ")";
            buttons[1] = GameObject.Find(find);
            x += 4;
            find = findbase + x.ToString() + ")";
            buttons[2] = GameObject.Find(find);
        }

        else if (x > 20 && x < 24)
        {
            buttons = new GameObject[3];
            x -= 1;
            find = findbase + x.ToString() + ")";
            buttons[0] = GameObject.Find(find);
            x += 2;
            find = findbase + x.ToString() + ")";
            buttons[1] = GameObject.Find(find);
            x -= 6;
            find = findbase + x.ToString() + ")";
            buttons[2] = GameObject.Find(find);
        }
        else if(x%5==0 && x!=0 && x!=20)
		{
            buttons = new GameObject[3];
            x -= 5;
            find = findbase + x.ToString() + ")";
            buttons[0] = GameObject.Find(find);
            x += 6;
            find = findbase + x.ToString() + ")";
            buttons[1] = GameObject.Find(find);
            x += 4;
            find = findbase + x.ToString() + ")";
            buttons[2] = GameObject.Find(find);
        }

        else if ((x+1) % 5 == 0 && x!=4 && x!=24)
        {
            buttons = new GameObject[3];
            x -= 5;
            find = findbase + x.ToString() + ")";
            buttons[0] = GameObject.Find(find);
            x += 4;
            find = findbase + x.ToString() + ")";
            buttons[2] = GameObject.Find(find);
            x += 6;
            find = findbase + x.ToString() + ")";
            buttons[1] = GameObject.Find(find);
        }

        else if(x == 0)
		{
            buttons = new GameObject[2];
            buttons[0] = GameObject.Find("Button (1)");
            buttons[1] = GameObject.Find("Button (5)");
        }
        else if (x == 4)
        {
            buttons = new GameObject[2];
            buttons[0] = GameObject.Find("Button (3)");
            buttons[1] = GameObject.Find("Button (9)");
        }
        else if (x == 24)
        {
            buttons = new GameObject[2];
            buttons[0] = GameObject.Find("Button (23)");
            buttons[1] = GameObject.Find("Button (19)");
        }
        else if (x == 20)
        {
            buttons = new GameObject[2];
            buttons[0] = GameObject.Find("Button (21)");
            buttons[1] = GameObject.Find("Button (15)");
        }
    }
        

    
    public void changeother()
    {
        int i = 0;
        while (i<buttons.Length)
        {
            buttons[i].GetComponent<colourchange>().change();
            i++;
        }
        
       
    }
}