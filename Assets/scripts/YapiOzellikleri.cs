using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YapiOzellikleri : MonoBehaviour
{
    public Yapi YapıKaynak;
	public Ayarlar ayarlarKaynak;
	public int kira;
	public int mutluluk;
	public int Seviye;
	public GameObject Canvas;
	public Text ParaTXT;
	public Text MutlulukTXT;
	public ParticleSystem ParaParticle;

	private void Start()
	{
		ayarlarKaynak.Yapılar.Add(this);

		kira = YapıKaynak.Kira;

		mutluluk = YapıKaynak.mutluluk;

		Seviye = YapıKaynak.Seviye;


		for (int i = 0; i < transform.childCount; i++)
		{
			if(transform.GetChild(i).name == "Para")
			{
				ParaParticle = transform.GetChild(i).GetComponent<ParticleSystem>();
			}
		}

		if (YapıKaynak.BinaTürü == Yapi.BinaTipi.ev)
		{
			InvokeRepeating("KiraÖde", 30, 30);

			Canvas = Instantiate(ayarlarKaynak.ÖrnekCanvas, ayarlarKaynak.ÖrnekCanvas.transform.position + new Vector3(gameObject.transform.position.x,0,gameObject.transform.position.z), ayarlarKaynak.ÖrnekCanvas.transform.rotation) as GameObject;

			InvokeRepeating("YavaşTekrar", 0, 0.5f);

			for (int i = 0; i < Canvas.transform.childCount; i++)
			{
				Canvas.transform.GetChild(i).gameObject.SetActive(true);
				for (int x = 0; x < Canvas.transform.GetChild(i).transform.childCount; x++)
				{
					if (Canvas.transform.GetChild(i).transform.GetChild(x).name == "ParaTXT")
					{
						ParaTXT = Canvas.transform.GetChild(i).transform.GetChild(x).GetComponent<Text>();
					}
					if (Canvas.transform.GetChild(i).transform.GetChild(x).name == "MutlulukTXT")
					{
						MutlulukTXT = Canvas.transform.GetChild(i).transform.GetChild(x).GetComponent<Text>();
					}


				}
			}

		}
		if (YapıKaynak.BinaTürü == Yapi.BinaTipi.fabrika)
		{
			for (int i = 0; i < ayarlarKaynak.Yapılar.Count; i++)
			{
				if(Vector3.Distance(ayarlarKaynak.Yapılar[i].gameObject.transform.position, gameObject.transform.position) <= YapıKaynak.EtkiAlanı)
				{
					ayarlarKaynak.Yapılar[i].kira += YapıKaynak.KiraArtışMiktarı;
					ayarlarKaynak.Yapılar[i].mutluluk -= YapıKaynak.MutlulukAzaltmaMiktarı;
				}
			}
		}
		if (YapıKaynak.BinaTürü == Yapi.BinaTipi.ağaç)
		{
			for (int i = 0; i < ayarlarKaynak.Yapılar.Count; i++)
			{
				if (Vector3.Distance(ayarlarKaynak.Yapılar[i].gameObject.transform.position, gameObject.transform.position) <= YapıKaynak.EtkiAlanı)
				{
					if (ayarlarKaynak.Yapılar[i].YapıKaynak.BinaTürü == Yapi.BinaTipi.ev)
					{
						ayarlarKaynak.Yapılar[i].mutluluk += YapıKaynak.MutlulukArtışMiktarı;
					}
				}
			}
		}
		if (YapıKaynak.BinaTürü == Yapi.BinaTipi.landmark)
		{
			for (int i = 0; i < ayarlarKaynak.Yapılar.Count; i++)
			{
				if (Vector3.Distance(ayarlarKaynak.Yapılar[i].gameObject.transform.position, gameObject.transform.position) <= YapıKaynak.EtkiAlanı)
				{
					if (ayarlarKaynak.Yapılar[i].YapıKaynak.BinaTürü == Yapi.BinaTipi.ev)
					{
						ayarlarKaynak.Yapılar[i].mutluluk += YapıKaynak.MutlulukArtışMiktarı;
						ayarlarKaynak.Yapılar[i].kira += YapıKaynak.KiraArtışMiktarı;
						InvokeRepeating("KiraÖde", 1, 1);
					}
				}
			}
		}

		


	}

	void YavaşTekrar()
	{
		ParaTXT.text = kira.ToString();
		MutlulukTXT.text = mutluluk.ToString();
		if(mutluluk < 0)
		{
			mutluluk = 0;
		}
	}



	void KiraÖde()
	{
		ayarlarKaynak.Para += kira;

		gameObject.GetComponent<AudioSource>().clip = ayarlarKaynak.KiraSes;
		gameObject.GetComponent<AudioSource>().Play();

		ParaParticle.Play();


		if (mutluluk <= 25 && kira >= YapıKaynak.Kira/2)
		{
			kira -= 10;
		}
	
		
		if(kira < YapıKaynak.Kira && mutluluk > 25)
		{
			kira += 10;
		}



	}
}
