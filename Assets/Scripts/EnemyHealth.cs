using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : Health
{
    public override void Death()
    {
		Destroy (gameObject, 0.2f);
    }
}
