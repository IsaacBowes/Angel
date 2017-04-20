using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public int ammo = 30;
    public Text uitext;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (uitext != null)
        {
            uitext.text = ammo.ToString();
        }
    }
}