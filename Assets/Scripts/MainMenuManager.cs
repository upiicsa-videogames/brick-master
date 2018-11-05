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

	private static bool sound = true;
	// Use this for initialization
	void Start () {
		
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
}
