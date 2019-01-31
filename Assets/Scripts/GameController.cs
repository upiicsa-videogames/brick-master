using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	[Header("Brick generation elements")]
	public GameObject brick;
	public Transform baseSpawn;
	GameObject newBrick;
	int bricksLaunched = 0;
	[Header("Character's textures")]
	public Sprite[] charactersTextures = new Sprite[3];
	[Header("Character settings")]
	public GameObject character;
	[Header("Game Settings")]
	public GameObject gameOver;
	private SpriteRenderer spriteRenderer; 
	private float posX, posY;
	// Use this for initialization

	void Start () 
	{
		posX = brick.transform.position.x;
		posY = brick.transform.position.y;
		spriteRenderer = character.GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = charactersTextures[Config.selectedCharacter];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape)) 
		{
			SceneManager.LoadScene("MainMenu");
		}
		
		if(Config.gameOver == true)
		{
			PlayerPrefs.SetInt("wasLaunched", 0);
			gameOver.SetActive(true);
		}
		if(bricksLaunched == 0)
		{
			if(brick.GetComponent<Rigidbody2D>().velocity == new Vector2(0,0) && PlayerPrefs.GetInt("wasLaunched") == 1)
			{
				newBrick = Instantiate(brick, baseSpawn) as GameObject;
				newBrick.transform.position = new Vector3(posX,posY,0);
				bricksLaunched++;
			}
		}
		else
		{
			if(newBrick.GetComponent<Rigidbody2D>().velocity == new Vector2(0,0) && PlayerPrefs.GetInt("wasLaunched") == 1 && bricksLaunched > 0 )
			{
				newBrick = Instantiate(brick, baseSpawn) as GameObject;
				newBrick.transform.position = new Vector3(posX,posY,0);
				bricksLaunched++;
			}
		}
	}

	public void GameOver()
	{
		gameOver.SetActive(true);
	}
}
