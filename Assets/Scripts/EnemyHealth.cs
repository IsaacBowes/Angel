using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : Health
{
	public int ammoDrop;
	PlayerShoot playerShoot;

	void Start()
	{
		playerShoot = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerShoot> ();
	}

    public override void Death()
    {
		playerShoot.Bullets += ammoDrop;
		Destroy (gameObject, 0.2f);
    }
}
