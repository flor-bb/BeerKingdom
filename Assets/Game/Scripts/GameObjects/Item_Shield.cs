using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shield : Collectible
{


    public override void OnCollect()
    {
        base.OnCollect();
        SaveGameData.current.inventory.shield = true;
        Destroy(gameObject);
    }
}
