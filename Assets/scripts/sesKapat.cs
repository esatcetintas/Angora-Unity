using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesKapat : MonoBehaviour
{
	public AudioListener AL;


	private void Start()
	{
		AL = gameObject.GetComponent<AudioListener>();
	}

	public void Ses()
	{
		AL.enabled = !AL.enabled;
	}
}
