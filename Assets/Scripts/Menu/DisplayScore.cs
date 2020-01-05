using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
	private Text ScoreText;
	
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = gameObject.GetComponent(typeof(Text)) as Text;
		ScoreText.text = PlayerPrefs.GetFloat("Score").ToString();
    }
}
