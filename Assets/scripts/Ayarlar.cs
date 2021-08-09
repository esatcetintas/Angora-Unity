using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ayarlar : MonoBehaviour
{
	public int Para;

	public List<YapiOzellikleri> Yapılar;

	public Text ParaText;

	public GameObject ÖrnekCanvas;

	public AudioClip KiraSes;

	[Header("Landmark")]

	public bool[] Landmarklar = new bool[5];

	private void Start()
	{
		Application.targetFrameRate = 60;
	}

	private void Update()
	{
		ParaText.text = Para.ToString();
	}

}
