using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
	public PlayerShoot playershoot;
    public Text uitext;
    // Use this for initialization
    void Start()
    {
    }

    void Update()
    {
		uitext.text = "" + playershoot.Bullets;
    }
}