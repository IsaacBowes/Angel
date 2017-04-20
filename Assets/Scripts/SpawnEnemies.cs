using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", 1f, .5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy()
	{
		float RandomX = Random.Range (0, 2);
		if (RandomX == 0)
			RandomX = -17;
		else
			RandomX = 17;
		GameObject obj = Instantiate (Resources.Load ("Tier3Enemy"), new Vector3 (RandomX, 0, Random.Range(-18, 18)), Quaternion.Euler(0, 0, 0)) as GameObject;
		obj.GetComponent<Enemy> ().player = player;
	}
}
