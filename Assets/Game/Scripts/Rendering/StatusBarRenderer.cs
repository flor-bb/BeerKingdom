using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Visualisiert den aktuellen Spielzustand in der Statusleiste
public class StatusBarRenderer : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI diamondLabel;


    void Start()
    {
        
    }

    // Update is called once per frame
   private void Update()
    {
        diamondLabel.text = SaveGameData.current.inventory.diamonds.ToString("D3");
        
    }
}
