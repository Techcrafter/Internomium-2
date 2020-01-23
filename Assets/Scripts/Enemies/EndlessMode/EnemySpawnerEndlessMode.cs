using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerEndlessMode : MonoBehaviour
{
	SoundManager SoundManager;
	
	GameObject Enemy;
	public GameObject Enemy001;
	public AudioClip SpawnEnemy001;
	
	GameObject Spawnpoint;
	GameObject Spawnpoint1;
	GameObject Spawnpoint2;
	GameObject Spawnpoint3;
	GameObject Spawnpoint4;
	
	int i;
	
    // Start is called before the first frame update
    void Start()
    {
		SoundManager = GameObject.Find("SoundPlayer").GetComponent<SoundManager>();
		
		PlayerPrefs.SetFloat("EnemiesToSpawn", 1);
		PlayerPrefs.SetFloat("EnemySpawnDelay", 5);
		PlayerPrefs.SetFloat("EnemyToSpawn", 1);
		
        Spawnpoint1 = GameObject.Find("Spawnpoint1");
		Spawnpoint2 = GameObject.Find("Spawnpoint2");
		Spawnpoint3 = GameObject.Find("Spawnpoint3");
		Spawnpoint4 = GameObject.Find("Spawnpoint4");
		
		StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	IEnumerator SpawnEnemies()
	{
		while(PlayerPrefs.GetFloat("EnemiesToSpawn") >= 1)
		{
			//Wait
			yield return new WaitForSeconds(PlayerPrefs.GetFloat("EnemySpawnDelay"));
			
			//Set enemy
			switch(PlayerPrefs.GetFloat("EnemyToSpawn"))
			{
				case 1:
					Enemy = Enemy001;
					SoundManager.PlayClip(SpawnEnemy001);
					break;
			}
			
			//Set spawnpoint
			switch(Random.Range(1, 5))
			{
				case 1:
					Spawnpoint = Spawnpoint1;
					break;
				
				case 2:
					Spawnpoint = Spawnpoint2;
					break;
				
				case 3:
					Spawnpoint = Spawnpoint3;
					break;
					
				case 4:
					Spawnpoint = Spawnpoint4;
					break;
			}
			
			//Instantiate enemy/enemies at spawnpoint(s)
			i = 0;
			while(i < PlayerPrefs.GetFloat("EnemiesToSpawn"))
			{
				i++;
				Instantiate(Enemy, Spawnpoint.transform.position, Quaternion.identity);
			}
		}
	}
}
