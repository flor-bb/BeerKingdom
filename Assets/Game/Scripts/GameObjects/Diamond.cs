using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Collectible
{

    public override void OnCollect()
    {
        base.OnCollect();// Does nothing
        Destroy(gameObject);
        //Erhöht den Diamantenzähler um 1
        SaveGameData.current.inventory.diamonds += 1;
    }

}
