using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

	public float bulletSpeed;
	AudioSource aS;

	// Use this for initialization
	void Start () {
		aS = transform.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(transform.forward * Time.deltaTime * bulletSpeed, Space.World);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Rock") {
			GameObject particle = Instantiate (Resources.Load ("Burst"), col.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
			Destroy (particle, 3);
			Destroy (gameObject);
			Destroy (col.gameObject);
			aS.PlayOneShot ((AudioClip)Resources.Load ("BulletHitSound"));
		} else if (col.tag == "Enemy") {
			GameObject particle = Instantiate (Resources.Load ("Burst"), col.transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
			aS.PlayOneShot ((AudioClip)Resources.Load ("BulletHitSound"));
			Destroy (particle, 3);
		}
	}

}
