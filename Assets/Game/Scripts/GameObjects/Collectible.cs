using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Basisklasse für alle Szenenobjekte welche aufgenommen werden können
public class Collectible : MonoBehaviour
{

    //Wird aufgerufen wenn das Objekt eingesammelt werden sollen.
    //Unterklassen sollen diese Methode überschreiben
    public virtual void OnCollect()
    {
        //empty
    }
}
