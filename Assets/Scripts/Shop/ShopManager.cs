using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("UpgradeMovementLevelText").GetComponent<Text>().text = (PlayerPrefs.GetFloat("MovementSpeed") + 1).ToString();
		GameObject.Find("UpgradeRotationLevelText").GetComponent<Text>().text = (PlayerPrefs.GetFloat("RotationSpeed") + 1).ToString();
		GameObject.Find("UpgradeMissilesLevelText").GetComponent<Text>().text = (PlayerPrefs.GetFloat("MissilesLevel") + 1).ToString();
		
		GameObject.Find("UpgradeMovementPriceText").GetComponent<Text>().text = ((PlayerPrefs.GetFloat("MovementSpeed") + 1)* 125).ToString();
		GameObject.Find("UpgradeRotationPriceText").GetComponent<Text>().text = ((PlayerPrefs.GetFloat("RotationSpeed") + 1)* 100).ToString();
		GameObject.Find("UpgradeMissilesPriceText").GetComponent<Text>().text = ((PlayerPrefs.GetFloat("MissilesLevel") + 1)* 150).ToString();
    }
	
	public void BuyUpgrade(int type)
	{
		switch(type)
		{
			//MovementSpeedSpeed
			case 1:
				if(PlayerPrefs.GetFloat("Coins") >= ((PlayerPrefs.GetFloat("MovementSpeed") + 1)* 125))
				{
					PlayerPrefs.SetFloat("Coins", PlayerPrefs.GetFloat("Coins") - ((PlayerPrefs.GetFloat("MovementSpeed") + 1)* 125));
					PlayerPrefs.SetFloat("MovementSpeed", PlayerPrefs.GetFloat("MovementSpeed") + 1);
					GameObject.Find("Canvas").GetComponent<SceneLoader>().LoadScene(1);
				}
				break;
			
			//RotationSpeedSpeed
			case 2:
				if(PlayerPrefs.GetFloat("Coins") >= ((PlayerPrefs.GetFloat("RotationSpeed") + 1)* 100))
				{
					PlayerPrefs.SetFloat("Coins", PlayerPrefs.GetFloat("Coins") - ((PlayerPrefs.GetFloat("RotationSpeed") + 1)* 100));
					PlayerPrefs.SetFloat("RotationSpeed", PlayerPrefs.GetFloat("RotationSpeed") + 1);
					GameObject.Find("Canvas").GetComponent<SceneLoader>().LoadScene(1);
				}
				break;
			
			//MissilesLevel
			case 3:
				if(PlayerPrefs.GetFloat("Coins") >= ((PlayerPrefs.GetFloat("MissilesLevel") + 1)* 150))
				{
					PlayerPrefs.SetFloat("Coins", PlayerPrefs.GetFloat("Coins") - ((PlayerPrefs.GetFloat("MissilesLevel") + 1)* 150));
					PlayerPrefs.SetFloat("MissilesLevel", PlayerPrefs.GetFloat("MissilesLevel") + 1);
					GameObject.Find("Canvas").GetComponent<SceneLoader>().LoadScene(1);
				}
				break;
		}
	}
}
