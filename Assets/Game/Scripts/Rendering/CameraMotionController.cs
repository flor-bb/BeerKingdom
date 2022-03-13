using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotionController : MonoBehaviour
{

    [SerializeField] private Hero hero;



    private void Update()
    {
        Vector3 heroPos = hero.transform.position; // Copy the position from hero object
        heroPos.z = transform.position.z; //keeps camera Z-Position
        transform.position = heroPos;
    }
}
