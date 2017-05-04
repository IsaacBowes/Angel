using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public LayerMask groundLayer;

	Waves waves;
	AudioSource aS;
	public AudioClip userDamagedDown;
	PlayerHealth playerhealth;

	// Use this for initialization
	void Start () {
		waves = GameObject.FindGameObjectWithTag ("WaveManager").GetComponent<Waves> ();
		aS = transform.GetComponent<AudioSource> ();
		playerhealth = transform.GetComponent<PlayerHealth> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 upAxis = new Vector3(0,0,-1);
		Vector3 mouseScreenPosition = Input.mousePosition;
		mouseScreenPosition.z = transform.position.z;
		//Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

		if(Physics.Raycast(ray, out hit, 1000f, groundLayer))
		{
			transform.LookAt(hit.point, upAxis);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		}


	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Enemy") {
			transform.GetComponent<PlayerHealth> ().AffectHealth (-1);
			transform.GetComponent<PlayerShoot>().Bullets += (col.collider.gameObject.GetComponent<EnemyHealth> ().ammoDrop + 1);
			aS.PlayOneShot (userDamagedDown);
			waves.TotalEnemiesInWave -= 1;
			StartCoroutine (playerhealth.hit ());
			Destroy (col.gameObject);
		}
	}
}
