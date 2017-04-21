using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PlayerHealth : Health
{
    

    public Text uitext;

    void Update()
    {
        if (uitext != null)
        {
            uitext.text = health.ToString();
        }
    }

public override void Death()
    {

    }
}
