using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrolörü : MonoBehaviour
{
    public int Puan;





    [Header("Karakter kontrolü")]



    public Vector3 YeniKonum;
    public int Hız = 2;
    public bool KoşuyorMu;
    public bool ZemindeMi;
    public bool ZıplıyorMu;
    public float yerdenYükseklik = 2;
    public bool MouseKilidi;
    public float ZeminleMesafe;

    public int Mert;

    private void Start()
    {
    }


    void Update()
    {
        gameObject.transform.Translate(Input.GetAxis("Horizontal")* Time.deltaTime * Hız, 0, Input.GetAxis("Vertical") * Time.deltaTime * Hız);

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, yerdenYükseklik, gameObject.transform.position.z);



        Debug.DrawRay(gameObject.transform.position,Vector3.down, Color.red);

        RaycastHit Hit;
        if (Physics.Raycast(gameObject.transform.position, Vector3.down,out Hit))
        {

            if (!ZıplıyorMu)
            {
                if (Hit.distance < 0.09f)
                {
                    yerdenYükseklik += 0.002f;
                }
                if (Hit.distance > 0.11f)
                {
                    yerdenYükseklik -= 0.002f;
                }
                if(Hit.distance < 0.05f)
                {
                    yerdenYükseklik += 0.02f;
                }

                if (Hit.distance > .2)
                {
                    yerdenYükseklik -= 0.02f;
                }


            }

            if(ZıplıyorMu)
            {
                if (Hit.distance < .1)
                {
                    ZıplıyorMu = false;
                }
            }
        }

        

        if(Input.GetButtonDown("HızlıKoş"))
        {
           
            if (!KoşuyorMu)
            {
                Hız = Hız * 2;
                KoşuyorMu = true;
            }
        }
        if(Input.GetButtonUp("HızlıKoş"))
        {
            if (KoşuyorMu)
            {
                Hız = Hız / 2;
                KoşuyorMu = false;
            }
        }

        if(Input.GetButtonDown("Jump"))
        {
            

            if (!ZıplıyorMu)
            {
                ZıplıyorMu = true;
                ZeminleMesafe = yerdenYükseklik;
            }
        }


        if(ZıplıyorMu)
        {
            Zıplama();

        }



        if(MouseKilidi)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;



            gameObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * 50, 0), Space.World);
            gameObject.GetComponentInChildren<Transform>().Rotate(-Input.GetAxis("Mouse Y") * Time.deltaTime * 50, 0, 0, Space.Self);
        }
        if (!MouseKilidi)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


        }


    }



    void Zıplama()
    {
        Mert++;
        yerdenYükseklik = ZeminleMesafe + 2*Mathf.Sin(Mert * Mathf.PI/45);
        if(Mert == 45)
        {
            ZıplıyorMu = false;
            Mert = 0;
        }
    }



}
