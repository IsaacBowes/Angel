﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocks : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x - Time.deltaTime, transform.position.y, transform.position.z);
		if (transform.position.x < -23) {
			Destroy (this);
		}
	}
}