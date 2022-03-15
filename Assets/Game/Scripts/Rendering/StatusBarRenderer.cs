using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


//Visualisiert den aktuellen Spielzustand in der Statusleiste
public class StatusBarRenderer : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI diamondLabel; // Zähler für Diamanten
    [SerializeField] private Image weaponARenderer; //Bild für Waffe auf Platz A


    void Start()
    {
        
    }

    // Update is called once per frame
   private void Update()
    {
        diamondLabel.text = SaveGameData.current.inventory.diamonds.ToString("D3"); //D3 für 3 Dezimalzahlen
        weaponARenderer.gameObject.SetActive(SaveGameData.current.inventory.shield);

        
    }
}
