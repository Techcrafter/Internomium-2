using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("MovementSpeed") == 0 || PlayerPrefs.GetFloat("RotationSpeed") == 0 || PlayerPrefs.GetFloat("Missile") == 0 || PlayerPrefs.GetFloat("Level") == 0)
		{
			PlayerPrefs.SetFloat("MovementSpeed", 1);
			PlayerPrefs.SetFloat("RotationSpeed", 1);
			PlayerPrefs.SetFloat("Missile", 1);
			PlayerPrefs.SetFloat("Level", 1);
		}
    }
}
