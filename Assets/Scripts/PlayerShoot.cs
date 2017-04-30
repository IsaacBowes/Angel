using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

    public int Bullets;
	public float cooldown;
	float counter = 11;
	public Waves waves; 
	public AudioClip ShootSound;
	public AudioClip HealthShootSound;
	public AudioClip EnemyDieSound;
	AudioSource aS;

	// Use this for initialization
	void Start () {
		aS = transform.GetComponent<AudioSource> ();	
	}

	IEnumerator waitShoot()
	{
		yield return new WaitForSeconds (.1f);
		counter = 0;
		Bullets--;
		GameObject bullet = Instantiate (Resources.Load ("Bullet"), transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
		bullet.transform.rotation = transform.rotation;
		aS.PlayOneShot (ShootSound);
	}
	
	// Update is called once per frame
	void Update () {
		if (counter > cooldown) {
			#if UNITY_ANDROID
			if (Input.GetMouseButtonDown (0)) {
				if (Bullets > 0) {
					StartCoroutine(waitShoot());
				}
			}
			#else
			if (Input.GetMouseButtonDown (0)) {
				if (Bullets > 0) {
					counter = 0;
					Bullets--;
					GameObject bullet = Instantiate (Resources.Load ("Bullet"), transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					bullet.transform.rotation = transform.rotation;
					aS.PlayOneShot (ShootSound);
				}
			}
			#endif
//				if (Bullets > 0) {
//					if (Input.GetTouch (0).tapCount == 0) {
//						counter = 0;
//						Bullets--;
//						GameObject bullet = Instantiate (Resources.Load ("Bullet"), transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
//						bullet.transform.rotation = transform.rotation;
//						aS.PlayOneShot (ShootSound);
//						Vector2 touch = Input.GetTouch (0).position;
//						Vector3 touchPos = new Vector3 (touch.x, touch.y, 0);
//						Quaternion lookrotation = Quaternion.LookRotation (touchPos);
//						transform.rotation = lookrotation;
//					}
//				}
//			if (Input.GetMouseButtonDown (1)) {
//				if (transform.GetComponent<PlayerHealth> ().health > 0) {
//					aS.PlayOneShot (HealthShootSound);
//					transform.GetComponent<PlayerHealth> ().AffectHealth (-1);
//					RaycastHit[] hits;
//					hits = Physics.RaycastAll (transform.position, transform.forward, 100);
//					GameObject bullet = Instantiate (Resources.Load ("CollatBullet"), transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
//					bullet.transform.rotation = transform.rotation;
//					bullet.transform.position += transform.forward * 8;
//					for (int i = 0; i < hits.Length; i++) {
//						RaycastHit hit = hits [i];
//						if (hit.collider.GetComponent<EnemyHealth> ()) {
//							aS.PlayOneShot (EnemyDieSound);
//							Destroy (hit.collider.gameObject, .2f);
//							waves.TotalEnemiesInWave -= 1;
//							Bullets += hit.collider.GetComponent<EnemyHealth> ().ammoDrop;
//							//hit.collider.GetComponent<EnemyHealth> ().AffectHealth (-);
//						} 
//					}
//				}
//			}
		}
	}

	void FixedUpdate()
	{
		counter += 0.2f;
	}
}
