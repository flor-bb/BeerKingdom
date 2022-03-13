using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Basisklasse f�r alle Szenenobjekte welche aufgenommen werden k�nnen
public class Collectible : MonoBehaviour
{

    //Wird aufgerufen wenn das Objekt eingesammelt werden sollen.
    //Unterklassen sollen diese Methode �berschreiben
    public virtual void OnCollect()
    {
        //empty
    }
}
