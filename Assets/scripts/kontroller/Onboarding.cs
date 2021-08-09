using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onboarding : MonoBehaviour
{
    public Sprite[] Resimler;
	public Image OnboardObje;
	public int Sıra;
	private bool basıldıMı;

	private void Start()
	{
		if (PlayerPrefs.GetInt("Onboard") == 0)
		{


			OnboardObje.gameObject.SetActive(true);
			Sıra = 0;
			SayfaAç(Sıra);
		}
		else
		{
			OnboardObje.gameObject.SetActive(false);
		}
	}





	public void OnBoardAç()
	{
		PlayerPrefs.SetInt("Onboard", 0);
		if (PlayerPrefs.GetInt("Onboard") == 0)
		{


			OnboardObje.gameObject.SetActive(true);
			Sıra = 0;
			SayfaAç(Sıra);
		}
		else
		{
			OnboardObje.gameObject.SetActive(false);
		}
	}


	private void Update()
	{
		if (PlayerPrefs.GetInt("Onboard") == 0)
		{
			if(Input.touchCount >= 1)
			{
				
				if (basıldıMı)
				{
					Sıra++;
					SayfaAç(Sıra);
					basıldıMı = false;
					return;
				}
			}
			if(Input.touchCount == 0)
			{
				basıldıMı = true;
			}

			if(Input.GetMouseButton(0))
			{
				if (basıldıMı)
				{
					Sıra++;
					SayfaAç(Sıra);
					basıldıMı = false;
					return;
				}
			}
		
			if(Input.GetMouseButtonUp(0))
			{
				basıldıMı = true;
			}


		}
	
		
	
	}

	public void SayfaAç(int değer)
	{
		if(değer == Resimler.Length)
		{
			PlayerPrefs.SetInt("Onboard", 1);
			Debug.Log("bitti");
			OnboardObje.gameObject.SetActive(false);
			this.enabled = false;
		}
		

		OnboardObje.sprite = Resimler[değer];
	
		


	}
}
