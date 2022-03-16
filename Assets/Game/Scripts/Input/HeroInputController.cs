using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Controlls the player the player
public class HeroInputController : MonoBehaviour
{

    //Hero Skript which should be controlled
    [SerializeField] private Hero hero;


    private void Update()
    {
        ControlHero();
    }

    private void ControlHero()
    {
        if (Input.GetKey(KeyCode.W))
        {
            hero.change.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            hero.change.y = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            hero.change.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            hero.change.x = -1;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            hero.PerformAction();
        }
    }
}
