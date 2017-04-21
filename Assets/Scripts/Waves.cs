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

	// Use this for initialization
	void Start () {
		
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
			roundstarted = true;
		}
        
        if (uitext != null)
        {
            uitext.text = int2roman.convert(WaveNumber+1);
        }

    }
}
