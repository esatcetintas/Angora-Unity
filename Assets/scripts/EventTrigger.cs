using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTrigger : MonoBehaviour
{
    public List<RandomEvent> Eventler;
	public Butonlar butonKaynak;
	public RandomEvent SeçiliEvent;
	public Ayarlar AyarlarKaynak;
	public List<RandomEvent> Landmark;

	public float süre;

	public Text BaşlıkTXT;
	public Text AçıklamaTXT;
	public Image ArkaPlan;
	
	
	public Text SeçimFiyatTXT;
	public Text SeçimMutlulukTXT;
	public Text UyarıFiyatTXT;
	public Text UyarıMutlulukTXT;


	public GameObject SeçimPencere;
	public GameObject UyarıPencere;
	public GameObject BilgilendirmePencere;





	private void Start()
	{
		InvokeRepeating("Rasgele", süre, süre);
		SeçiliEvent = null;
	}


	void Rasgele()
	{
		int sayı = Random.Range(0, Eventler.Count);
		Event(sayı);
	}

	

	public void LandmarkAç(int değer)
	{
		butonKaynak.EventAç();
		SeçiliEvent = Landmark[değer];

		BaşlıkTXT.text = SeçiliEvent.İsim;
		AçıklamaTXT.text = SeçiliEvent.Açıklama;


		ArkaPlan.sprite = SeçiliEvent.Resim;

		SeçimPencere.SetActive(false);
		UyarıPencere.SetActive(false);
		BilgilendirmePencere.SetActive(true);
	}

	public void Event(int değer)
	{
		butonKaynak.EventAç();
		SeçiliEvent = Eventler[değer];

		BaşlıkTXT.text = SeçiliEvent.İsim;
		AçıklamaTXT.text = SeçiliEvent.Açıklama;


		ArkaPlan.sprite = SeçiliEvent.Resim;

		if(SeçiliEvent.Tür == RandomEvent.EventTipi.Seçim)
		{
			SeçimPencere.SetActive(true);
			UyarıPencere.SetActive(false);
			BilgilendirmePencere.SetActive(false);

			SeçimFiyatTXT.text = SeçiliEvent.Para.ToString();
			SeçimMutlulukTXT.text = SeçiliEvent.Mutluluk.ToString();

		}
		
		if (SeçiliEvent.Tür == RandomEvent.EventTipi.Uyarı)
		{
			SeçimPencere.SetActive(false);
			UyarıPencere.SetActive(true);
			BilgilendirmePencere.SetActive(false);
			
			UyarıFiyatTXT.text = SeçiliEvent.Para.ToString();
			UyarıMutlulukTXT.text = SeçiliEvent.Mutluluk.ToString();
		}

		if (SeçiliEvent.Tür == RandomEvent.EventTipi.Bilgilendirme)
		{
			SeçimPencere.SetActive(false);
			UyarıPencere.SetActive(false);
			BilgilendirmePencere.SetActive(true);
		}

	}


	public void Onay()
	{
		if (SeçiliEvent.Tür == RandomEvent.EventTipi.Seçim)
		{
			AyarlarKaynak.Para -= SeçiliEvent.Para;
			butonKaynak.Geri();
		}

		if (SeçiliEvent.Tür == RandomEvent.EventTipi.Uyarı)
		{
			AyarlarKaynak.Para += SeçiliEvent.Para;
			butonKaynak.Geri();
		}


		
	}

	public void Red()
	{
		if(SeçiliEvent.Tür == RandomEvent.EventTipi.Seçim)
		{
			foreach (YapiOzellikleri Yapı in AyarlarKaynak.Yapılar)
			{
				Yapı.mutluluk -= SeçiliEvent.Mutluluk;
			}

			butonKaynak.Geri();

		}
		
	}

}
