using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GOWaveText : MonoBehaviour {

	public Text WaveNumberText;
	Text thisText;
	public bool gameisover = false;

	// Use this for initialization
	void Start () {
		thisText = transform.GetComponent<Text> ();
		thisText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameisover) {
			thisText.text = "" + transform.name;
		} else {
			transform.name = WaveNumberText.text;
		}
		//transform.GetComponent<Text> ().text = "" + WaveNumberText.text;
	}
}
