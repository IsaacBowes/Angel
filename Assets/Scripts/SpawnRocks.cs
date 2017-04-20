using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour {

	int counter = 1;
	float timer = 0;
	int randomtime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		timer += .2f;
		if (timer > randomtime) {
			timer = 0;
			SpawnRock ();
		}
	}

	void SpawnRock()
	{
		GameObject rock = Instantiate (Resources.Load ("Rock"), new Vector3 (20, 0, Random.Range (-20, 20)), Quaternion.Euler (0, 0, 0)) as GameObject;
		rock.transform.parent = transform;
		counter++;
		randomtime = Random.Range (10, 20);
	}

}
