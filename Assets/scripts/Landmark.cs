using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmark : MonoBehaviour
{
    public int Sıra;
    
    void Start()
    {
        GameObject ayar = GameObject.Find("ayarlar");
        ayar.GetComponent<Ayarlar>().Landmarklar[Sıra-1] = true;
        ayar.GetComponent<EventTrigger>().LandmarkAç(Sıra -1 );

        Ayarlar Landmarklar = ayar.GetComponent<Ayarlar>();


        if(Landmarklar.Landmarklar[0])
		{
            if (Landmarklar.Landmarklar[1])
			{
                if (Landmarklar.Landmarklar[2])
				{
                    if (Landmarklar.Landmarklar[3])
					{
                        if (Landmarklar.Landmarklar[4])
						{
                            ayar.GetComponent<EventTrigger>().LandmarkAç(5);
						}

                    }

                }

            }

        }
    }

}
