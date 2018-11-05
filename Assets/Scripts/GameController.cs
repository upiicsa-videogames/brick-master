using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	[Header("Brick generation elements")]
	public GameObject brick;
	public Transform baseSpawn;
	GameObject newBrick;
	int bricksLaunched = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(bricksLaunched == 0)
		{
			if(brick.GetComponent<Rigidbody2D>().velocity == new Vector2(0,0) && PlayerPrefs.GetInt("wasLaunched") == 1)
			{
				newBrick = Instantiate(brick, baseSpawn);
				newBrick.transform.position = new Vector3(-0.3f,0,0);
				bricksLaunched++;
				print(bricksLaunched);
			}
		}
		else
		{
			if(newBrick.GetComponent<Rigidbody2D>().velocity == new Vector2(0,0) && PlayerPrefs.GetInt("wasLaunched") == 1 && bricksLaunched > 0 )
			{
				newBrick = Instantiate(brick, baseSpawn);
				newBrick.transform.position = new Vector3(-0.3f,0,0);
				bricksLaunched++;
				print(bricksLaunched);
			}
		}
		
	}
}
