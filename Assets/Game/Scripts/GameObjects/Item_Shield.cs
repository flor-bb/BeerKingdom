using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Einsammelbares Schild Objekt auf der Karte
/// </summary>
public class Item_Shield : Collectible
{


    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameData.current.inventory.shield = true;
        Destroy(gameObject);
    }
}
