using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Erkennt die Überschneidung von COllidern ohne Physikengine
/// Ruft CallBack bei KOllisionen auf
/// </summary>
public class CollisionDetector : MonoBehaviour
{
    protected BoxCollider2D boxCollider;   //Box collider which detects collision
    protected Collider2D[] colliders;   // Contains all collider which are collided with
    protected ContactFilter2D obstacleFilter; // Filter der Kollisionsobjekte als Hindernisse findet (Trigger werden ignoriert)
    protected int numFound = 0; // Speichert die Anzahl bei der letzten KOllisionsprüfung gefundenen Kollisionspartner


    /// <summary>
    /// Gibt an wie die Funktion aussehen muss die bei einer
    /// Kollision aufgerufen wird
    /// </summary>
    public delegate void Callback(Collider2D collider);

    /// <summary>
    /// Speicherplatz für eine Funktion die aufgerufen wird wenn die Kollision stattfindet
    /// </summary>

    protected virtual void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        colliders = new Collider2D[10];
        obstacleFilter = new ContactFilter2D();
    }

    public Callback WhenCollisionDetected;


    //Checks if the player is Colliding with other Colliders
    protected bool IsColliding()
    {
        numFound = boxCollider.OverlapCollider(obstacleFilter, colliders);
        return numFound > 0;

    }

    protected void Update()
    {

        if (WhenCollisionDetected != null)
        {
            enabled = false;
        }
        else if (IsColliding())
        {
            for (int i = 0; i < numFound; i++)
            {
                WhenCollisionDetected(colliders[i]);
            }

        }
    }

}
