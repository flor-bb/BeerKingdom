using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    //Zeigt auf den Schwert Animator
    [SerializeField] private Animator anim;

    //Zeigt auf den Animator der Figur um die Laufrichtung zu ermitteln
    //Parameter lookAt muss die Richtung enthalten
    [SerializeField] private Animator characterAnimator;


    protected void Start()
    {
        SetVisible(false);
    }

    //Wird ausgeführt wenn das Schwert enabled wird
    public void OnEnable()
    {
        AnimationEventDelegate.WhenTimeLineEventReached += OnTimeLineEvent; //Methode wird der Liste hinzugefügt wenn Schwert Enabled wird
    }

    //Wird ausgeführt wenn das Schwert disabled wird
    public void OnDisable()
    {
        AnimationEventDelegate.WhenTimeLineEventReached -= OnTimeLineEvent; //Entfernt die Methode wenn das Schwert disabled wird

    }

    //Führt einen Schwerschlag aus
    public void Stroke()
    {
        int lookAt = Mathf.RoundToInt(characterAnimator.GetFloat("lookAt")); //Rundet auf Int um floating fehler zu vermeiden

        //Parameter um das Schwert zu rotieren
        float scaleX = 1f;
        float rotateZ = 0f;

        if (lookAt == 0)
        {
            rotateZ = 90f;
        }
        else if (lookAt == 1)
        {
            rotateZ = 0f;
        }
        else if (lookAt == 2)
        {
            rotateZ = -90f;
        }
        else if (lookAt == 3)
        {
            rotateZ = 0f;
            scaleX = -1f;
        }

        //Richtet das Schwert aus
        transform.localScale = new Vector3(scaleX, 1f, 1f);
        transform.localRotation = Quaternion.Euler(0f, 0f, rotateZ);

        SetVisible(true);

        anim.SetTrigger("onStroke");

    }

    //Steuert die Sichtbarkeit des Schwers
    private void SetVisible(bool isVisible)
    {
        anim.gameObject.SetActive(isVisible);

    }


    //Blendet das Schwert am Ende der Angriffsanimation aus
    public void OnTimeLineEvent()
    {
        SetVisible(false);
    }


}
