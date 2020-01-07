using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscore : MonoBehaviour
{
	Text HighscoreText;
	
    // Start is called before the first frame update
    void Start()
    {
        HighscoreText = gameObject.GetComponent(typeof(Text)) as Text;
		HighscoreText.text = PlayerPrefs.GetFloat("Highscore").ToString();
    }
}
