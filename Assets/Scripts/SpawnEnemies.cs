using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnEnemies : MonoBehaviour {

	public GameObject player;
	public Waves waves;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", 1f, .5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy()
	{
		if (waves.TotalEnemiesInWave > 0) {
			float RandomX = UnityEngine.Random.Range (0, 2);
			if (RandomX == 0)
				RandomX = -17;
			else
				RandomX = 17;
			int ChoseEnemy = UnityEngine.Random.Range (0, 3);
			if (ChoseEnemy == 0) {
				if (waves.waves [waves.WaveNumber].Tier3EnemyAmount > 0) {
					AddEnemy ("Tier3Enemy", RandomX);
					waves.waves [waves.WaveNumber].Tier3EnemyAmount -= 1;
				}
			} else if (ChoseEnemy == 1) {
				if (waves.waves [waves.WaveNumber].Tier2EnemyAmount > 0) {
					AddEnemy ("Tier2Enemy", RandomX);
					waves.waves [waves.WaveNumber].Tier2EnemyAmount -= 1;
				}
			} else {
				if (waves.waves [waves.WaveNumber].Tier1EnemyAmount > 0) {
					AddEnemy ("Tier1Enemy", RandomX);
					waves.waves [waves.WaveNumber].Tier1EnemyAmount -= 1;
				}
			}
		}
	}

	void AddEnemy(string str, float RandomX)
	{
		GameObject obj = Instantiate (Resources.Load (str), new Vector3 (RandomX, 0, UnityEngine.Random.Range (-18, 18)), Quaternion.Euler (0, 0, 0)) as GameObject;
		obj.GetComponent<Enemy> ().player = player;
	}
}
