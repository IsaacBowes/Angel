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
		GameObject particle = Instantiate (Resources.Load ("FlashRing02"), transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
		Destroy (particle, 3);
		Destroy (gameObject);
    }
}
