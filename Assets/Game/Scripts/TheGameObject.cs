using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Super Klasse for GameObjects
//Containts functions usable for all GameObjects
public class TheGameObject : MonoBehaviour
{

    private BoxCollider2D boxCollider;   //Box collider which detects collision
    private Collider2D[] colliders;   // Contains all collider which are collided with
    private Animator anim; // Point to the Animator

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        colliders = new Collider2D[10];
        anim = GetComponent<Animator>();
        //Caps the FPS at 30, so the player does not move too fast
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }



    //change that the player should move in this frame
    public Vector3 change = new Vector3();

    //LateUpdate is called when all updates from all scripts are called
    private void LateUpdate()
    {

        anim.SetFloat("change_x", change.x);
        anim.SetFloat("change_y", change.y);


        //Controls in which direction the player will look at after a movement
        if (change.y <= -1f)
        {
            anim.SetFloat("lookAt", 0f);
        }
        else if (change.x <= -1f)
        {
            anim.SetFloat("lookAt", 1f);
        }
        else if (change.y >= 1f)
        {
            anim.SetFloat("lookAt", 2f);
        }
        else if(change.x >= 1f)
        {
            anim.SetFloat("lookAt", 3f);
        }

        //Used to move objexts
        float step = RoundToPixelGrid(1f * Time.deltaTime);
        Vector3 oldPos = transform.position;
        transform.position += change * step;
        if (IsColliding()) transform.position = oldPos;
        change = Vector3.zero;


    }

    //float für Pixel berechnung
    private static float pixelFrac = 1f / 16f; //  16 = Pixel per unit
    //Runde auf PixelArt Pixel
    protected float RoundToPixelGrid(float f)
    {

        return Mathf.Ceil(f / pixelFrac) * pixelFrac;

    }

    //Checks if the player is Colliding with other Colliders
    protected bool IsColliding()
    {

        return (boxCollider.OverlapCollider(new ContactFilter2D(), colliders) > 0);

    }
}
