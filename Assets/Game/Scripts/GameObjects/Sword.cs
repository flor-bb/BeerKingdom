using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    [SerializeField] private Animator anim;

    //Führt einen Schwerschlag aus
    public void Stroke()
    {
        anim.SetTrigger("onStroke");

    }


}
