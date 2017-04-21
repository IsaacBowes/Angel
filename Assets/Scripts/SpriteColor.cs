using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColor : MonoBehaviour {

	EnemyHealth enemyhealth;
	public Color halfHealthColor;
	public Color QuaterHealthColor;
	SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		enemyhealth = transform.GetComponentInParent<EnemyHealth> ();
		sprite = transform.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		float percent = enemyhealth.health * 100 / enemyhealth.maxHealth;
		if (percent >= 50 && percent != 100) {
			sprite.color = halfHealthColor;
		} else if (percent >= 33 && percent != 100) {
			sprite.color = QuaterHealthColor;
		}
	}
}
