﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	NavMeshAgent agent;
	public GameObject player;
	public float speed;
	public float KnockBack;
	EnemyHealth enemyhealth;
	bool paused = false;

	// Use this for initialization
	void Start () {
		if (transform.name != "Tier3Enemy(Clone)") {
			agent = GetComponent<NavMeshAgent> ();
		}
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyhealth = transform.GetComponent<EnemyHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (paused) {
				paused = false;
			} else {
				paused = true;
			}
		}
		if (paused) {
			//agent.isStopped = true;
		} else {
			if (transform.name != "Tier3Enemy(Clone)") {
				agent.destination = player.transform.position;
				agent.speed = speed;
			}
			else {
				transform.position = Vector3.MoveTowards (transform.position, player.transform.position, (speed / 50));
				transform.LookAt (player.transform.position);
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Bullet") {
			enemyhealth.AffectHealth (-1);
			transform.position -= transform.forward * KnockBack;
			Destroy (col.gameObject);
		}
	}

}
