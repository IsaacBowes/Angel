using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : Health
{
	public int ammoDrop;
	PlayerShoot playerShoot;
	Waves waves;
	AudioSource aS;

	void Start()
	{
		playerShoot = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerShoot> ();
		waves = GameObject.FindGameObjectWithTag ("WaveManager").GetComponent<Waves> ();
		aS = transform.GetComponent<AudioSource> ();
	}

    public override void Death()
    {
		playerShoot.Bullets += ammoDrop;
		waves.TotalEnemiesInWave -= 1;
		aS.PlayOneShot ((AudioClip)Resources.Load ("EnemyDieSound"));
		Destroy (gameObject);
    }
}
