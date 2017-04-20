using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public int Bullets;
	public float cooldown;
	float counter = 11;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (counter > cooldown) {
			if (Bullets > 0) {
				if (Input.GetMouseButtonDown (0)) {
					counter = 0;
					Bullets--;
					GameObject bullet = Instantiate (Resources.Load ("Bullet"), transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
					bullet.transform.rotation = transform.rotation;
					bullet.transform.position += transform.forward * 8;

                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
                    {
                        if (hit.collider.GetComponent<EnemyHealth> ()) {
                        	hit.collider.GetComponent<EnemyHealth> ().AffectHealth (-1);
                        }
                    }
                    //RaycastHit[] hits;
                    //hits = Physics.RaycastAll (transform.position, transform.forward, 100);
                    //for (int i = 0; i < hits.Length; i++) {
                    //	RaycastHit hit = hits [i];
                    //	if (hit.collider.GetComponent<EnemyHealth> ()) {
                    //		hit.collider.GetComponent<EnemyHealth> ().AffectHealth (-1);
                    //	}
                    //}
                    Destroy (bullet, 1);
				}
			}
		}
	}

	void FixedUpdate()
	{
		counter += 0.2f;
	}
}
