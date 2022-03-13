using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Datenspeicher für den aktuellen Spielstand
public class SaveGameData 
{

    //Der aktuelle Spielstand
    public static SaveGameData current = new SaveGameData();
    //Speicher für einsammelbare Gegenstände
    public Inventory inventory = new Inventory();

}
