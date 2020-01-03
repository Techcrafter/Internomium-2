using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour {
	
	private GameObject LoadingText;
	
	// Start is called before the first frame update
    void Start()
    {
        LoadingText = GameObject.Find("LoadingText");
		LoadingText.SetActive(false);
    }
	
	public void loadScene(int level)
	{
		LoadingText.SetActive(true);
		Application.LoadLevel(level);
	}
	
	public void quitGame()
	{
		LoadingText.SetActive(true);
		Application.Quit();
	}
}
