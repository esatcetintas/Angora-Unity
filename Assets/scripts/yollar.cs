using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yollar : MonoBehaviour
{
	public int değer;

	private void Start()
	{
		transform.Rotate(new Vector3(0, değer, 0),Space.Self);
		if(değer == 90)
		{
			transform.Translate(new Vector3(-0.5f, 0, 0.5f));
		}


		if (değer == 180)
		{
			transform.Translate(new Vector3(-0.5f, 0, -0.5f));
		}

		if (değer == 270)
		{
			transform.Translate(new Vector3(0.5f, 0, -1.5f));
		}


	}

}
