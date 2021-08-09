
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yerles : MonoBehaviour
{
	public Tile kaynak;
	public GameObject Merkez;
	public Yapi YapıKaynak;
	public GameObject Ayarlar;
	public Ayarlar ayarlarKaynak;
	public TileClass seçiliTile;
	public Text İsim;
	public Text Para;
	public Text Mutluluk;
	public Text Kira;

	public void TabloGüncelle()
	{
		İsim.text = YapıKaynak.name;
		Para.text = YapıKaynak.Fiyat.ToString();
		if (YapıKaynak.BinaTürü == Yapi.BinaTipi.ev)
		{
			Mutluluk.text = YapıKaynak.mutluluk.ToString();
			Kira.text = YapıKaynak.Kira.ToString();

		}
		if (YapıKaynak.BinaTürü == Yapi.BinaTipi.fabrika)
		{
			Mutluluk.text = YapıKaynak.MutlulukAzaltmaMiktarı.ToString();

			Kira.text = YapıKaynak.KiraArtışMiktarı.ToString();
		}
		if (YapıKaynak.BinaTürü == Yapi.BinaTipi.ağaç)
		{
			Mutluluk.text = YapıKaynak.MutlulukArtışMiktarı.ToString();
		}
	}

	void Start()
	{

		Ayarlar = GameObject.Find("ayarlar");
		kaynak = Ayarlar.GetComponent<Tile>();
		ayarlarKaynak = Ayarlar.GetComponent<Ayarlar>();

		TabloGüncelle();

	}


	// Update is called once per frame
	void Update()
	{
		YerleşimKontrol();

		if (Input.GetButtonDown("Submit"))
		{
			BinaYerleştir();
		}

	}


	public void BinaYerleştir()
	{
		if(YapıKaynak.Fiyat <= ayarlarKaynak.Para)
		{
			Debug.Log("para var");
			if(!seçiliTile.DoluMu)
			{
				Debug.Log("tile boş");
				if(YapıKaynak.Büyüklük == 1)
				{
					
					GameObject Yerleştirilen = Instantiate(YapıKaynak.Model, transform.position - new Vector3(0.5f, 0.5f, 0.5f), transform.rotation) as GameObject;
					YapiOzellikleri özellik = Yerleştirilen.AddComponent<YapiOzellikleri>() as YapiOzellikleri;
					özellik.YapıKaynak = YapıKaynak;
					özellik.ayarlarKaynak = ayarlarKaynak;
					ayarlarKaynak.Para -= YapıKaynak.Fiyat;
					Debug.Log("Yerleştirildi");

				}

				if (YapıKaynak.Büyüklük == 2)
				{
					GameObject Yerleştirilen = Instantiate(YapıKaynak.Model, transform.position - new Vector3(1.5f, 0.5f, 1.5f), transform.rotation) as GameObject;
					YapiOzellikleri özellik = Yerleştirilen.AddComponent<YapiOzellikleri>() as YapiOzellikleri;
					özellik.YapıKaynak = YapıKaynak;
					özellik.ayarlarKaynak = ayarlarKaynak;
					ayarlarKaynak.Para -= YapıKaynak.Fiyat;
					
				}


				seçiliTile.DoluMu = true;
				TabloGüncelle();
				if(YapıKaynak.Büyüklük == 2)
				{
					for (int i = 0; i < kaynak.Köşegenler.Count; i++)
					{
						if(Vector3.Distance(kaynak.Köşegenler[i].Konum,gameObject.transform.position) <= 1.9f)
						{
							kaynak.Köşegenler[i].DoluMu = true;
						}
					}
				}
			}
		}
	}


	void YerleşimKontrol()
	{
		for (int i = 0; i < kaynak.Köşegenler.Count; i++)
		{
			if (Vector3.Distance(kaynak.Köşegenler[i].Konum, Merkez.transform.position) < 0.5f)
			{
				gameObject.transform.position = kaynak.Köşegenler[i].Konum;
				seçiliTile = kaynak.Köşegenler[i];
			}
		}
	}

}
