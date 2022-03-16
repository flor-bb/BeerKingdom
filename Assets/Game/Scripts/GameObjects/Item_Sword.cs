using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Einsammelbares Schwert auf der Karte
/// </summary>
public class Item_Sword : Collectible
{


    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameData.current.inventory.sword = true;
        Destroy(gameObject);
    }
}
