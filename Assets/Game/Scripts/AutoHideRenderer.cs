using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHideRenderer : MonoBehaviour
{

    private void Start()
    {
        Renderer r = GetComponent<Renderer>();
        if (r != null)
        {
            r.enabled = false;
        }
    }


}
