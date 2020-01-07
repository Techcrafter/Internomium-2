using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevel : MonoBehaviour
{
	Text LevelText;
	
    // Start is called before the first frame update
    void Start()
    {
        LevelText = gameObject.GetComponent(typeof(Text)) as Text;
		LevelText.text = PlayerPrefs.GetFloat("Level").ToString();
    }
}
