using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

	public GameObject player;
	public Waves waves;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy()
	{
		SpawnTier1 ();
		SpawnTier2 ();
		SpawnTier3 ();
	}

	void SpawnTier3()
	{
		float RandomX = UnityEngine.Random.Range (0, 2);
		if (RandomX == 0)
			RandomX = -17;
		else
			RandomX = 17;
		if (waves.waves [waves.WaveNumber].Tier3EnemyAmount > 0) {
			AddEnemy ("Tier3Enemy", RandomX);
			waves.waves [waves.WaveNumber].Tier3EnemyAmount -= 1;
		}
	}

	void SpawnTier2()
	{
		float RandomX = UnityEngine.Random.Range (0, 2);
		if (RandomX == 0)
			RandomX = -17;
		else
			RandomX = 17;
		if (waves.waves [waves.WaveNumber].Tier2EnemyAmount > 0) {
			AddEnemy ("Tier2Enemy", RandomX);
			waves.waves [waves.WaveNumber].Tier2EnemyAmount -= 1;
		}
	}

	void SpawnTier1()
	{
		float RandomX = UnityEngine.Random.Range (0, 2);
		if (RandomX == 0)
			RandomX = -17;
		else
			RandomX = 17;
		if (waves.waves [waves.WaveNumber].Tier1EnemyAmount > 0) {
			AddEnemy ("Tier1Enemy", RandomX);
			waves.waves [waves.WaveNumber].Tier1EnemyAmount -= 1;
		}
	}

	void AddEnemy(string str, float RandomX)
	{
		GameObject obj = Instantiate (Resources.Load (str), new Vector3 (RandomX, 0, UnityEngine.Random.Range (-18, 18)), Quaternion.Euler (0, 0, 0)) as GameObject;
		obj.GetComponent<Enemy> ().player = player;
	}
}
