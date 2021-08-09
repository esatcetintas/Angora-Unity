using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class belediye : MonoBehaviour
{
    public GameObject[] Seviyeler = new GameObject[3];
    public int CurSeviye;
    public GameObject CurBina;
	public Vector3 konum;
	public Ayarlar AyarlarKaynak;
	public int[] fiyatlar = new int[2];

	private void Start()
	{

		konum = CurBina.transform.position;
	}

	public void Yükselt()
	{
		if(CurSeviye < 2)
		{
			AyarlarKaynak.Para -= fiyatlar[CurSeviye];
			GameObject.Destroy(CurBina);
			CurSeviye++;
			GameObject yerleştirilen = Instantiate(Seviyeler[CurSeviye], konum - new Vector3(0, 0, 3f), transform.rotation) as GameObject;
			CurBina = yerleştirilen;
		}
	}
}
