using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Helferklasse um ein Ereignis in einer Animation weiterzuleiten
public class AnimationEventDelegate : MonoBehaviour
{

    //Definiert den Funktionsaufbau der Callback Methode
    public delegate void Callback();

    //Eine "Liste" die Funtkionen des delegate Callback enthält
    public static event Callback WhenTimeLineEventReached;

    public void OnTimeLineEvent()
    {
       if(WhenTimeLineEventReached != null)
        {
            WhenTimeLineEventReached();
        }
    }

}
