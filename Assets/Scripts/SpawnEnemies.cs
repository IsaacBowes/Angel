using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		SpawnEnemy ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy()
	{
		Instantiate (Resources.Load ("Enemy"), new Vector3 (-17, 0, Random.Range(-18, 18)), Quaternion.Euler(0, 0, 0));
	}
}
