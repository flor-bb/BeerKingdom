using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Datenspeicher f�r den aktuellen Spielstand
public class SaveGameData 
{

    //Der aktuelle Spielstand
    public static SaveGameData current = new SaveGameData();
    //Speicher f�r einsammelbare Gegenst�nde
    public Inventory inventory = new Inventory();

}
