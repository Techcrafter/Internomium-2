using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		gameObject.GetComponent<Text>().text = PlayerPrefs.GetFloat("Level").ToString();
    }
}
