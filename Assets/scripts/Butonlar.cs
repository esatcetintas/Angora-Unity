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
    private void Start()
    {
        YapılarUI.SetActive(true);
        YapıPenceresiUI.SetActive(false);
        LandmarkPenceresi.SetActive(false);
        YapıImage.SetActive(false);
        EventEkranı.SetActive(false);
        ParkEkranı.SetActive(false);
        YolEkranı.SetActive(false);
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

        YolEkranı.SetActive(false);
        ParkEkranı.SetActive(false);
        YapılarUI.SetActive(false);
        YapıPenceresiUI.SetActive(true);
        LandmarkPenceresi.SetActive(false);
        EventEkranı.SetActive(false);
    }


    public void Landmark()
	{
        YapılarUI.SetActive(false);
        YapıPenceresiUI.SetActive(false);
        LandmarkPenceresi.SetActive(true);
        EventEkranı.SetActive(false);
        ParkEkranı.SetActive(false);
        YolEkranı.SetActive(false);
    }

    public void Yollar()
    {
        YapılarUI.SetActive(false);
        YapıPenceresiUI.SetActive(false);
        LandmarkPenceresi.SetActive(false);
        EventEkranı.SetActive(false);
        ParkEkranı.SetActive(false);
        YolEkranı.SetActive(true);
    }


    public void ParkAç()
    {
        YapılarUI.SetActive(false);
        YapıPenceresiUI.SetActive(false);
        LandmarkPenceresi.SetActive(false);
        EventEkranı.SetActive(false);
        ParkEkranı.SetActive(true);
        YolEkranı.SetActive(false);
    }

    public void HousePanel()
    {
        YapılarUI.SetActive(false);
        YapıPenceresiUI.SetActive(false);
        LandmarkPenceresi.SetActive(false);
        EventEkranı.SetActive(false);
        ParkEkranı.SetActive(true);
        YolEkranı.SetActive(false);
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
        YapılarUI.SetActive(false);
        YapıPenceresiUI.SetActive(false);
        LandmarkPenceresi.SetActive(false);
        EventEkranı.SetActive(true);
        ParkEkranı.SetActive(false);


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
        GameObject.Destroy(GameObject.Find("merkez"));
        GameObject.Destroy(Yerleştirici);

        BinaTaşımaKaynak.Taşınabilir = true;
        MK.HareketliMi = true;
        YapılarUI.SetActive(true);
        YapıPenceresiUI.SetActive(false);
        LandmarkPenceresi.SetActive(false);
        YapıImage.SetActive(false);
        EventEkranı.SetActive(false);
        ParkEkranı.SetActive(false);
        YolEkranı.SetActive(false);
    }

}
