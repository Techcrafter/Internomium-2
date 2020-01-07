using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagementEndlessMode : MonoBehaviour
{
	Text HpText;
	Text CoinsText;
	Text ScoreText;
	
	GameObject NewHighscoreText;
	
	Scrollbar HorizontalScrollbar;
	Scrollbar VerticalScrollbar;
	
	RectTransform CanvasRectTransform;
	
	GameObject PlayerMissile001;
	
	SoundManager SoundManager;
	
	public AudioClip PlayerMissile001Sound;
	public AudioClip TakeNormalHitSound;
	public AudioClip Collect10CoinsSound;
	public AudioClip Collect1HPSound;
	
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
		
        HpText = GameObject.Find("HpText").GetComponent<Text>();
		CoinsText = GameObject.Find("CoinsText").GetComponent<Text>();
		ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		
		NewHighscoreText = GameObject.Find("NewHighscoreText");
		NewHighscoreText.SetActive(false);
		
		HorizontalScrollbar = GameObject.Find("HorizontalScrollbar").GetComponent(typeof(Scrollbar)) as Scrollbar;
		VerticalScrollbar = GameObject.Find("VerticalScrollbar").GetComponent(typeof(Scrollbar)) as Scrollbar;
		
		CanvasRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
		
		PlayerMissile001 = GameObject.Find("PlayerMissile001");
		
		SoundManager = GameObject.Find("SoundPlayer").GetComponent<SoundManager>();
		
		movementSpeed = PlayerPrefs.GetFloat("MovementSpeed");
		rotationSpeed = PlayerPrefs.GetFloat("RotationSpeed");
    }

    // Update is called once per frame
    void Update()
    {
		angle = transform.eulerAngles.magnitude * Mathf.Deg2Rad;
		angle += 1.6f;
		cacheX = transform.position.x;
		cacheY = transform.position.y;
        cacheX -= (Mathf.Cos (angle) * ((VerticalScrollbar.value - 0.5f) * -movementSpeed)) * Time.deltaTime;
		cacheY -= (Mathf.Sin (angle) * ((VerticalScrollbar.value - 0.5f) * -movementSpeed)) * Time.deltaTime;
		if(cacheX > (-13.2f*(CanvasRectTransform.rect.width/800)) && cacheX < (13.2f*(CanvasRectTransform.rect.width/800)))
		{
			transform.position = new Vector3(cacheX, transform.position.y, 0);
		}
		if(cacheY > (-7.65f*(CanvasRectTransform.rect.height/600)) && cacheY < (10.5f*(CanvasRectTransform.rect.height/600)))
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
		switch(PlayerPrefs.GetFloat("Missile"))
		{
			case 1:
				SoundManager.PlayClip(PlayerMissile001Sound);
				Destroy(Instantiate(PlayerMissile001, transform.position, transform.rotation), 3);
				break;
		}
	}
	
	public void TakeHit(int hp)
	{
		switch(hp)
		{
			case 1:
				SoundManager.PlayClip(TakeNormalHitSound);
				break;
		}
		PlayerPrefs.SetFloat("HP", PlayerPrefs.GetFloat("HP") - hp);
	}
	
	public void CollectHP(int hp)
	{
		switch(hp)
		{
			case 1:
				SoundManager.PlayClip(Collect1HPSound);
				break;
		}
		PlayerPrefs.SetFloat("HP", PlayerPrefs.GetFloat("HP") + hp);
	}
	
	public void CollectCoins(int coins)
	{
		switch(coins)
		{
			case 10:
				SoundManager.PlayClip(Collect10CoinsSound);
				break;
		}
		PlayerPrefs.SetFloat("Coins", PlayerPrefs.GetFloat("Coins") + coins);
	}
}
