using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : Health
{
	public int ammoDrop;
	PlayerShoot playerShoot;
	Waves waves;

	void Start()
	{
		playerShoot = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerShoot> ();
		waves = GameObject.FindGameObjectWithTag ("WaveManager").GetComponent<Waves> ();
	}

    public override void Death()
    {
		playerShoot.Bullets += ammoDrop;
		waves.TotalEnemiesInWave -= 1;
		Destroy (gameObject);
    }
}
