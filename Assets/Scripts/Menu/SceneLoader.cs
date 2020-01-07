using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour {
	
	GameObject LoadingText;
	
	// Start is called before the first frame update
    void Start()
    {
        LoadingText = GameObject.Find("LoadingText");
		LoadingText.SetActive(false);
    }
	
	public void LoadScene(int level)
	{
		LoadingText.SetActive(true);
		Application.LoadLevel(level);
	}
	
	public void QuitGame()
	{
		LoadingText.SetActive(true);
		Application.Quit();
	}
}
