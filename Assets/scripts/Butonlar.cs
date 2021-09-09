using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Butonlar : MonoBehaviour
{
    public GameObject YapılarUI;
    public GameObject YapıPenceresiUI;
    public GameObject LandmarkPenceresi;
    public Object YerleştiriciKaynak;
    public GameObject Yerleştirici;
    public MobilKontrol MK;
    public List<Yapi> Yapılar;
    public Ayarlar AyarlarKaynak;
    public Tile TileKaynak;
    public BinaTasima BinaTaşımaKaynak;
    public GameObject YapıImage;
    public belediye BelediyeKaynak;
    public GameObject EventEkranı;
    public GameObject ParkEkranı;
    public GameObject housePanel;
    public GameObject YolEkranı;
    public GameObject[] Panels;
    private void Start()
    {
        OpenPanel(0);
    }



    public void OpenPanel(int val)
	{
        foreach(GameObject panel in Panels)
		{
            if(panel == Panels[val])
			{
                panel.SetActive(true);
			}
            else
			{
                panel.SetActive(false);
			}
		}
	}

    public void YapıPenceresiAç(int Sıra )
    {
        MK.HareketliMi = false;


        YapıImage.SetActive(true);

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hit))
        {
            Vector3 konum = new Vector3(Mathf.RoundToInt(hit.point.x), 0.5f, Mathf.RoundToInt(hit.point.z));


            GameObject Yerleştirilen = Instantiate(YerleştiriciKaynak, konum - new Vector3(0.5f, 0, 0.5f), transform.rotation) as GameObject;

            Yerleştirilen.transform.GetChild(0).transform.parent = null;

            if (Yapılar[Sıra].Büyüklük == 2)
            {
                Yerleştirilen.transform.localScale = new Vector3(3, 1, 3);
            }

            Yerleştirilen.GetComponent<yerles>().YapıKaynak = Yapılar[Sıra];

            Yerleştirici = Yerleştirilen;
        }

        OpenPanel(1);
    }


    public void Landmark()
	{
        OpenPanel(2);
    }

    public void Yollar()
    {
        OpenPanel(5);
    }


    public void ParkAç()
    {
        OpenPanel(4);
    }

    public void HousePanel()
    {
        OpenPanel(6);
    }

    public void FactoryPanel()
    {
        OpenPanel(7);
    }


    public void Yerleştir()
    {
        Yerleştirici.GetComponent<yerles>().BinaYerleştir();
        Geri();
    }

    public void Yükselt()
	{
        
        Debug.Log("basıldı");
        if (Yerleştirici.GetComponent<yerles>().seçiliTile.DoluMu)
		{
            for (int i = 0; i < AyarlarKaynak.Yapılar.Count; i++)
            {
                if (Vector3.Distance(Yerleştirici.transform.position, AyarlarKaynak.Yapılar[i].gameObject.transform.position) <= 1f)
                {
                    int seviye = AyarlarKaynak.Yapılar[i].Seviye;
                    Debug.Log(seviye);

                    if(seviye <= BelediyeKaynak.CurSeviye)
					{
                        Sat();
                        if (seviye == 1)
                        {
                            if (Yerleştirici.GetComponent<yerles>().YapıKaynak.BinaTürü == Yapi.BinaTipi.ev)
                            {
                                Yerleştirici.GetComponent<yerles>().YapıKaynak = Yapılar[3];
                                Yerleştir();
                            }
                            if (Yerleştirici.GetComponent<yerles>().YapıKaynak.BinaTürü == Yapi.BinaTipi.fabrika)
                            {
                                Yerleştirici.GetComponent<yerles>().YapıKaynak = Yapılar[4];
                                Debug.Log("seviye 2ye yükselt");
                                Yerleştir();
                            }
                        }
                        if (seviye == 2)
                        {
                            if (Yerleştirici.GetComponent<yerles>().YapıKaynak.BinaTürü == Yapi.BinaTipi.ev)
                            {
                                Yerleştirici.GetComponent<yerles>().YapıKaynak = Yapılar[5];
                                Yerleştir();
                            }
                            if (Yerleştirici.GetComponent<yerles>().YapıKaynak.BinaTürü == Yapi.BinaTipi.fabrika)
                            {
                                Yerleştirici.GetComponent<yerles>().YapıKaynak = Yapılar[6];
                                Yerleştir();
                            }
                        }
                    }
                }
            }
        }

    }


    public void EventAç()
	{
        OpenPanel(3);
    }


    public void Sat()
	{
        if(Yerleştirici.GetComponent<yerles>().seçiliTile.DoluMu)
		{
            for (int i = 0; i < AyarlarKaynak.Yapılar.Count; i++)
			{
                if(Vector3.Distance(Yerleştirici.transform.position,AyarlarKaynak.Yapılar[i].gameObject.transform.position) <= 1f)
				{
                    if(AyarlarKaynak.Yapılar[i].gameObject.GetComponent<YapiOzellikleri>().Canvas != null)
					{
                        GameObject.Destroy(AyarlarKaynak.Yapılar[i].gameObject.GetComponent<YapiOzellikleri>().Canvas);
					}

                    Debug.Log("satıldı");
                    GameObject.Destroy(AyarlarKaynak.Yapılar[i].gameObject);
                    Yerleştirici.GetComponent<yerles>().seçiliTile.DoluMu = false;
                    AyarlarKaynak.Para += AyarlarKaynak.Yapılar[i].YapıKaynak.Fiyat;
                    AyarlarKaynak.Yapılar.Remove(AyarlarKaynak.Yapılar[i]);
                }
			}
		}
	}


    public void Geri()
    {
        Destroy(GameObject.Find("merkez"));
        Destroy(Yerleştirici);

        BinaTaşımaKaynak.Taşınabilir = true;
        MK.HareketliMi = true;
        OpenPanel(0);
    }

}
