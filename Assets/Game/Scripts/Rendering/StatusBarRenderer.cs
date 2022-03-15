using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


//Visualisiert den aktuellen Spielzustand in der Statusleiste
public class StatusBarRenderer : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI diamondLabel; // Z�hler f�r Diamanten
    [SerializeField] private Image weaponARenderer; //Bild f�r Waffe auf Platz A


    void Start()
    {
        
    }

    // Update is called once per frame
   private void Update()
    {
        diamondLabel.text = SaveGameData.current.inventory.diamonds.ToString("D3"); //D3 f�r 3 Dezimalzahlen
        weaponARenderer.gameObject.SetActive(SaveGameData.current.inventory.shield);

        
    }
}
