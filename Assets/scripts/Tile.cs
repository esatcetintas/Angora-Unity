using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tile : MonoBehaviour
{
    public List<TileClass> Köşegenler;
    public int TileUzunluk;


    void Start()
    {
        for (int x = 0; x < TileUzunluk; x++)
        {
            for (int y = 0; y < TileUzunluk; y++)
            {
                TileClass tile = new TileClass();
                tile.Konum = new Vector3(x+ 0.5f, 0.5f, y+ 0.5f);
                Köşegenler.Add(tile);
            }
        }



        Köşegenler[1273].DoluMu = true;
        Köşegenler[1274].DoluMu = true;
        Köşegenler[1275].DoluMu = true;
        Köşegenler[1223].DoluMu = true;
        Köşegenler[1224].DoluMu = true;
        Köşegenler[1225].DoluMu = true;
        Köşegenler[1174].DoluMu = true;
        Köşegenler[1173].DoluMu = true;
        Köşegenler[1175].DoluMu = true;
    }


	// Update is called once per frame
	void Update()
    {
        
    }
}
