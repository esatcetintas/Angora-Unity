using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]


[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event")]
public class RandomEvent : ScriptableObject
{
	public string İsim;
	public string Açıklama;
	public Sprite Resim;

	public enum EventTipi
	{
		Seçim,
		Uyarı,
		Bilgilendirme
	};
	public EventTipi Tür;

	public int Para;
	public int Mutluluk;


}
