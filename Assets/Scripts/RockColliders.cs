using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockColliders : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Bullet") {
			Destroy (col.gameObject);
		}
	}

}
