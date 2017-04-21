using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

	public float bulletSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(transform.forward * Time.deltaTime * bulletSpeed, Space.World);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Rock") {
			Destroy (gameObject);
		}
	}

}
