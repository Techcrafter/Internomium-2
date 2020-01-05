using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagementEndlessMode : MonoBehaviour
{
	private Text HpText;
	private Text CoinsText;
	private Text ScoreText;
	
	private GameObject NewHighscoreText;
	
	private Scrollbar HorizontalScrollbar;
	private Scrollbar VerticalScrollbar;
	
	float angle;
	float cacheX;
	float cacheY;
	float movementSpeed;
	float rotationSpeed;
	
    // Start is called before the first frame update
    void Start()
    {
		PlayerPrefs.SetFloat("HP", 3);
		PlayerPrefs.SetFloat("Score", 0);
		
        HpText = GameObject.Find("HpText").GetComponent(typeof(Text)) as Text;
		CoinsText = GameObject.Find("CoinsText").GetComponent(typeof(Text)) as Text;
		ScoreText = GameObject.Find("ScoreText").GetComponent(typeof(Text)) as Text;
		
		NewHighscoreText = GameObject.Find("NewHighscoreText");
		NewHighscoreText.SetActive(false);
		
		HorizontalScrollbar = GameObject.Find("HorizontalScrollbar").GetComponent(typeof(Scrollbar)) as Scrollbar;
		VerticalScrollbar = GameObject.Find("VerticalScrollbar").GetComponent(typeof(Scrollbar)) as Scrollbar;
		
		movementSpeed = PlayerPrefs.GetFloat("MovementSpeed");
		rotationSpeed = PlayerPrefs.GetFloat("RotationSpeed");
    }

    // Update is called once per frame
    void Update()
    {
		angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;
		angle += 1.6f;
        cacheX -= (Mathf.Cos (angle) * ((VerticalScrollbar.value - 0.5f) * -movementSpeed)) * Time.deltaTime;
		cacheY -= (Mathf.Sin (angle) * ((VerticalScrollbar.value - 0.5f) * -movementSpeed)) * Time.deltaTime;
		if(cacheX > -9.7f && cacheX < 9.7f)
		{
			transform.position = new Vector3(cacheX, transform.position.y, 0);
		}
		if(cacheY > -4.5f && cacheY < 4.5f)
		{
			transform.position = new Vector3(transform.position.x, cacheY, 0);
		}
		
		gameObject.transform.Rotate(0f, 0f, (HorizontalScrollbar.value - 0.5f) * -rotationSpeed);
		
		HpText.text = PlayerPrefs.GetFloat("HP").ToString();
		if(PlayerPrefs.GetFloat("HP") <= 0)
		{
			GameObject.Find("Canvas").GetComponent<SceneLoader>().LoadScene(4);
		}
		CoinsText.text = PlayerPrefs.GetFloat("Coins").ToString();
		ScoreText.text = PlayerPrefs.GetFloat("Score").ToString();
		if(PlayerPrefs.GetFloat("Score") > PlayerPrefs.GetFloat("Highscore"))
		{
			NewHighscoreText.SetActive(true);
		}
    }
	
	public void Shoot()
	{
		
	}
}
