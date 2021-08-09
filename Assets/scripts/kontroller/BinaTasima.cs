using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaTasima : MonoBehaviour
{
    public GameObject YapıPenceresi;
    public GameObject merkez;
    public bool Taşınabilir;




	private void Start()
	{
        Taşınabilir = true;
	}
	void Update()
    {
        if(YapıPenceresi != null)
		{
            if (YapıPenceresi.activeSelf)
            {
                if (merkez == null)
                {
                    merkez = GameObject.Find("merkez");
                }
                if (Input.touchCount > 0 && Input.touchCount < 2)
                {
                    checkTouch(Input.GetTouch(0).position);
                }
            }
        }
    }

    public void TaşınabilirMi(bool değer)
	{
        Taşınabilir = değer;
	}
    
    private void checkTouch(Vector3 pos)
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(pos), out hit))
		{
            if(Taşınabilir)
			{
                if (hit.collider.tag == "zemin")
                {
                    merkez.transform.position = new Vector3(hit.point.x, 0.5f, hit.point.z);
                }
            }
		}
    }

}
