using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Movement : MonoBehaviour {
	Highscore hScore; 
	public float timestep = 0.2F; 
	float time;
    Vector3 secondDir;
	CubeArray cA;
	public Camera tetrisCamera;
	private bool horizontalMove = true;
    public bool gameOver = false;

	//The actual group which can rotate and will move down
	public GameObject actualGroup;
    ScoreManager scoreManager;
    public GameObject ScoreManager;


    void Start()
    {
		cA = gameObject.GetComponent<CubeArray> (); 
		hScore = gameObject.GetComponent<Highscore> ();
        gameOver = false;
        scoreManager = ScoreManager.GetComponent<ScoreManager>();
    }

	public void startGame()
    {
		actualGroup = this.gameObject.GetComponent<GroupSpawner> ().spawnNext ();
	}
	//Move down in interval of timestep
	void Update () 
    {
		time += Time.deltaTime;
        //Vector3 secondDir = direction();
		if (time > timestep)
        {
			time = 0;
            //defaultMove();
            move(Vector3.down);
            if (horizontalMove)
            {
	            move(secondDir);
            }
        }
		if(tetrisCamera.enabled)
			checkForInput (); 
	}

	void checkForInput()
    {
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
        {
			actualGroup.GetComponent<Rotation>().rotateRight (false); 
		} 
        else if (Input.GetKeyDown (KeyCode.Mouse1)) 
        {
			actualGroup.GetComponent<Rotation>().rotateLeft (false); 
		}
		if (Input.GetKeyDown (KeyCode.A)) 
        {
			move (Vector3.left);
		} 
        else if (Input.GetKeyDown (KeyCode.D)) 
        {
			move (Vector3.right);
		}
		if (Input.GetKeyDown (KeyCode.S)) 
        {
			timestep = 0.05F; 
		}
        else if (Input.GetKeyUp(KeyCode.S))
        {
            gameObject.GetComponent<Highscore>().setNewSpeed();
        }
        cA.updateArrayBool ();
	}

	void move(Vector3 pos)
    {
		if (actualGroup != null)
		{
			horizontalMove = true;
			actualGroup.transform.position += pos; 
			if (!cA.updateArrayBool ())
			{
				horizontalMove = false;
				actualGroup.transform.position -= pos; 
				gameObject.GetComponent<ManageAudio> ().playCantMove (); 
				if(pos == Vector3.down)
                {
					spawnNew ();
                    secondDir = direction();
                    //print("Hi");
				}
			}
		}
	}

    public Vector3 direction()
    {
        int i = Random.Range(1, 4);
        switch (i)
        {
            case 1:
                return Vector3.down;
            case 2:
                return Vector3.right;
            case 3:
                return Vector3.left;
        }
        return Vector3.down;
    }


    //Handle spawning a new group and check if there is any intersection after spawning
    private void spawnNew()
    {
        if(!hScore.gameOver)
        {
            actualGroup.GetComponent<Rotation>().isActive = false;
            actualGroup = gameObject.GetComponent<GroupSpawner>().spawnNext();
            actualGroup.GetComponent<Rotation>().isActive = true;
            //secondDir = gameObject.GetComponent<GroupSpawner>().direction();
            if (!cA.updateArrayBool())
            {
                hScore.gameOver = true;
                scoreManager.ScoreUpdater(hScore.points, "tetris", "anshal");
                print("GAME OVER!!!");

                //Application.LoadLevel (Application.loadedLevelName); 
            }
            else
            {
                cA.checkForFullLine();
                //Debug.Log("called");
            }
        }  
	}
}