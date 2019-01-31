using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	[Header ("Setting's buttons")]
	public Sprite soundON;
	public Sprite soundOFF;
	public Button soundBtn;
	public Text soundBtnText;
	public GameObject[] cursors = new GameObject[3];

	private static bool sound = true;
	// Use this for initialization
	void Start () 
	{
		SelectedCharacter(Config.selectedCharacter);	
		Config.gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenLinks(string link)
	{
		Application.OpenURL (link);
	}

	public void OpenScenes(string scene)
	{
		SceneManager.LoadScene(scene);
	}

	public void SoundBtnOnClick()
	{
		sound = (!sound);
		if(sound == true)
		{
			soundBtn.GetComponent<Image>().sprite = soundON;
			soundBtnText.color = Color.black;
		}
		else
		{
			soundBtn.GetComponent<Image>().sprite = soundOFF;
			soundBtnText.color = Color.white;
		}
	}

	public void SelectedCharacter(int character)
	{
		foreach (GameObject cursor in cursors)
		{
			cursor.SetActive(false);
		}
		cursors[character].SetActive(true);
		Config.selectedCharacter = character;
	}
}
