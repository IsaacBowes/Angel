using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class AllWaves {
	public int Tier3EnemyAmount;
	public int Tier2EnemyAmount;
	public int Tier1EnemyAmount;
	public float SpawnRate;
}

public class Waves : MonoBehaviour {

	public int TotalEnemiesInWave;
	public AllWaves[] waves;
	public int WaveNumber;
	bool roundstarted = true;
	public SpawnEnemies spawnenemies;
    public Text uitext;
	PlayerShoot player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot> ();
	}


// Update is called once per frame
void Update () {
		if (roundstarted) {
			spawnenemies.CancelInvoke ();
			spawnenemies.InvokeRepeating("SpawnEnemy", 1f, waves[WaveNumber].SpawnRate);
			TotalEnemiesInWave = (waves [WaveNumber].Tier1EnemyAmount + waves [WaveNumber].Tier2EnemyAmount + waves [WaveNumber].Tier3EnemyAmount);
			roundstarted = false;
		}
		if (TotalEnemiesInWave <= 0) {
			WaveNumber++;
			player.Bullets += 1;
			roundstarted = true;
			if (WaveNumber == waves.Length) {
				WaveNumber = waves.Length - 1;
			}
		}
        
        if (uitext != null)
        {
            uitext.text = int2roman.convert(WaveNumber+1);
        }

    }
}
