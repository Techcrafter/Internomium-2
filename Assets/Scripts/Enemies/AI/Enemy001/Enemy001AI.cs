using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy001AI : MonoBehaviour
{
	GameObject Player;
	
	float mSpeed = 0.01f;
	float rSpeed = 0.5f;
	
	float posX;
	float posY;
	
	float xDiff = 5f;
	float yDiff = 3f;
	
	int rotCycle;
	float rotZ;
	
	public GameObject EnemyMissile001;
	
	public GameObject Item10Coins;
	public GameObject Item1Hp;
	
	SoundManager SoundManager;
	
	public AudioClip EnemyMissile001Sound;
	public AudioClip DestroyEnemy001Sound;
	
    // Start is called before the first frame update
    void Start()
    {
		Player = GameObject.Find("Player");
		
        SoundManager = GameObject.Find("SoundPlayer").GetComponent<SoundManager>();
		StartCoroutine(ShootTimer());
    }

    // Update is called once per frame
    void Update()
    {
		//Move
		posX = transform.position.x;
		posY = transform.position.y;
		
		if(transform.position.x < Player.transform.position.x - xDiff)
		{
			posX += mSpeed;
		}
		else if(transform.position.x > Player.transform.position.x + xDiff)
		{
			posX -= mSpeed;
		}
		
		if(transform.position.y < Player.transform.position.y - yDiff)
		{
			posY += mSpeed;
		}
		else if(transform.position.y > Player.transform.position.y + yDiff)
		{
			posY -= mSpeed;
		}
		
		transform.position = new Vector3(posX, posY, 0);
		
		//Rotate
		if(rotCycle == 0)
		{
			switch(Random.Range(1, 3))
			{
				case 1:
					rotZ = -rSpeed;
					break;
				
				case 2:
					rotZ = rSpeed;
					break;
			}
		}
		
		rotCycle++;
		
		if(rotCycle == 100)
		{
			rotCycle = 0;
		}
		
		transform.Rotate(0, 0, rotZ);
    }
	
	IEnumerator ShootTimer()
	{
		while(true)
		{
			yield return new WaitForSeconds(Random.Range(1, 4));
			Shoot();
		}
	}
	
	void Shoot()
	{
		SoundManager.PlayClip(EnemyMissile001Sound);
		Destroy(Instantiate(EnemyMissile001, transform.position, transform.rotation), 3);
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		switch(collider.gameObject.tag)
		{
			//Destroy
			case "PlayerMissile001":
				SoundManager.PlayClip(DestroyEnemy001Sound);
				PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score") + 1);
				if(Random.Range(1, 11) != 10)
				{
					Destroy(Instantiate(Item10Coins, transform.position, Quaternion.identity), 15);
				}
				else
				{
					Destroy(Instantiate(Item1Hp, transform.position, Quaternion.identity), 15);
				}
				Destroy(gameObject);
				break;
		}
	}
}
