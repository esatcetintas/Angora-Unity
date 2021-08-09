using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


[CreateAssetMenu(fileName = "Yapı", menuName = "ScriptableObjects/Yapı")]
public class Yapi: ScriptableObject
{
	public int Büyüklük;
	public enum BinaTipi
	{
		ev,
		ağaç,
		fabrika,
		landmark,
		dükkan
	};

	public BinaTipi BinaTürü;

	public Object Model;

	public int Fiyat;

	public int Seviye;

	public float EtkiAlanı;


	[Header("Ev")]
	public int Kira;
	public int mutluluk;




	[Header("Ağaç")]

	public int MutlulukArtışMiktarı;



	[Header("Fabrika")]
	public int MutlulukAzaltmaMiktarı;
	public int KiraArtışMiktarı;
}
