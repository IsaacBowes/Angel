using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

    public Text uitext;
    public int Bullets;
	public float cooldown;
	float counter = 11;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (counter > cooldown) {
			if (Input.GetMouseButtonDown (0)) {
				if (Bullets > 0) {
					counter = 0;
					Bullets--;
					GameObject bullet = Instantiate (Resources.Load ("Bullet"), transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					bullet.transform.rotation = transform.rotation;
					if (uitext != null) {
						uitext.text = Bullets.ToString ();
					}
				}
			}
			if (Input.GetMouseButtonDown (1)) {
				if (transform.GetComponent<PlayerHealth> ().health > 0) {
					transform.GetComponent<PlayerHealth> ().AffectHealth (-1);
					RaycastHit[] hits;
					hits = Physics.RaycastAll (transform.position, transform.forward, 100);
					GameObject bullet = Instantiate (Resources.Load ("CollatBullet"), transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					bullet.transform.rotation = transform.rotation;
					bullet.transform.position += transform.forward * 8;
					for (int i = 0; i < hits.Length; i++) {
						RaycastHit hit = hits [i];
						if (hit.collider.GetComponent<EnemyHealth> ()) {
							Destroy (hit.collider.gameObject, .2f);
							//hit.collider.GetComponent<EnemyHealth> ().AffectHealth (-1);
						} 
					}
				}
			}
		}
	}

	void FixedUpdate()
	{
		counter += 0.2f;
	}
}
