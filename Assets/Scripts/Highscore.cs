using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour 
{
	public int level, rows, points;
    public bool gameOver; 
	// Use this for initialization
	void Start () 
    {
		rows = 0; 
		points = 0;
        level = 0;
        gameOver = false;
        setNewSpeed();
	}

    public void setNewSpeed()
    {
        gameObject.GetComponent<Movement>().timestep = ((10 - level) * 0.05F);
    }

    public void addPointsForLines(int lines){
		if (lines > 0) 
        {
			switch (lines) 
            {
			case 1:
				points += 40; 
				break;
			case 2: 
				points += 100; 
				break; 
			case 3: 
				points += 300; 
				break;
			case 4: 
				points += 1200; 
				break; 
			}
			rows += lines;
            level = (int) rows / 10;
		}
	}

	//Add points for each group which was added
	public void addPointsForCubes()
    {
		points += 4; 
		//transmitToUI (); 
	}

	/*public void transmitToUI(){
		highscoreText.text = points.ToString (); 
		levelText.text = level.ToString (); 
		rowText.text = rows.ToString (); 
	}*/
}
