using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PlayerHealth : Health
{
    public Text uitext;
	public Transform bodyparts;
	public Renderer[] characterParts;
	public Color healthFlickerColor;
	Color ogcolor;

    void Update()
    {
        if (uitext != null)
        {
            uitext.text = health.ToString();
        }
    }

	void Start()
	{
		int temp = 0;
		foreach (Transform part in bodyparts) {
			if (part.tag == "CharacterParts") {
				characterParts [temp] = part.GetComponent<Renderer>();
				ogcolor = part.GetComponent<Renderer>().material.color;
				temp++;
			}
		}
	}

	void SetColor(Color col)
	{
		bodyparts.GetComponent<MeshRenderer> ().material.color = col;
		foreach (Renderer part in characterParts) {
			part.material.color = col;
		}
	}

	public IEnumerator hit()
	{
		SetColor (healthFlickerColor);
		yield return new WaitForSeconds (.3f);
		SetColor (ogcolor);
		yield return new WaitForSeconds (.3f);
		SetColor (healthFlickerColor);
		yield return new WaitForSeconds (.3f);
		SetColor (ogcolor);
		yield return new WaitForSeconds (.3f);
		SetColor (healthFlickerColor);
		yield return new WaitForSeconds (.3f);
		SetColor (ogcolor);
	}

	public override void Death()
    {

    }
}
