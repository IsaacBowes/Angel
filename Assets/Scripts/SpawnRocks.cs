using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour {

	int counter = 1;
	float timer = 0;
	int randomtime = 0;
	public int SpawnMin;
	public int SpawnMax;

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
		//GameObject rock = Instantiate (Resources.Load ("Rock"), new Vector3 (20, -.59f, Random.Range (-20, 20)), Quaternion.Euler (0, 0, 0)) as GameObject;
		GameObject rock = Instantiate (Resources.Load ("Rock"), new Vector3 (20, -.59f, Random.Range (-10, 10)), Quaternion.Euler (0, 0, 0)) as GameObject;
		float random = Random.Range (0.25f, 0.6f);
		rock.transform.parent = transform;
		rock.transform.localScale = new Vector3 (random, random, random);
		rock.transform.Rotate(0, Random.Range (0, 360), 0);
		if (rock.transform.position.z < 7.6f && rock.transform.position.z > -7.4f) {
			Destroy (rock.gameObject);
		}
		counter++;
		randomtime = Random.Range (SpawnMin, SpawnMax);
	}

}
