using System;
using UnityEngine;


//Hero Specific functions
public class Hero : TheGameObject
{
    private ContactFilter2D triggerContactFilter;


    //Sprites für den Charakter für verschiedene Skins
    [SerializeField] private RuntimeAnimatorController emptySkin;
    [SerializeField] private RuntimeAnimatorController shieldSkin;



    protected override void Awake()
    {
        base.Awake();
        triggerContactFilter = new ContactFilter2D();
        triggerContactFilter.useTriggers = true;
    }

    private void Update()
    {
        int found = boxCollider.OverlapCollider(triggerContactFilter, colliders);
        for (int i = 0; i < found; i++)
        {
            Collider2D foundCollider = colliders[i];
            if (foundCollider.isTrigger)
            {
                //Colliders für Aufnehmbare Objekte
                foreach (Collectible collectible in foundCollider.GetComponents<Collectible>())
                {
                    collectible.OnCollect();
                }
            }
        }

        //Checkt welchen Skin ausgerüstet werden soll
        if (SaveGameData.current.inventory.shield)
        {
            anim.runtimeAnimatorController = shieldSkin;
        }
        else
        {
            anim.runtimeAnimatorController = emptySkin;
        }
    }

    //Reaktion auf Aktiontastendruck
    public void PerformAction()
    {

        if (!SaveGameData.current.inventory.sword) //Wenn das Schwert nicht vorhanden ist --> Abbruch
        {
            return;
        }
        anim.enabled = false;

        //Animation wird dem Listener hinzugefügt
        AnimationEventDelegate.WhenTimeLineEventReached += ResetSkin;
        if (SaveGameData.current.inventory.shield)
        {
            shieldActionSkin.Apply(GetComponent<SpriteRenderer>(), Mathf.RoundToInt(anim.GetFloat("lookAt")));
        }
        else
        {
            emptyActionSkin.Apply(GetComponent<SpriteRenderer>(), Mathf.RoundToInt(anim.GetFloat("lookAt")));
        }
        Sword sword = GetComponentInChildren<Sword>();
        sword.Stroke();
    }

    private void ResetSkin()
    {
        anim.enabled = true;
        AnimationEventDelegate.WhenTimeLineEventReached -= ResetSkin;
    }

    //Sprite um Schlagaktion ohne schild zu zeigen
    public SpriteSet emptyActionSkin;
    //Sprite um Schlagaktion mit schild zu zeigen
    public SpriteSet shieldActionSkin;


    //Helferklasse in Klasse um Sprites des Heros zu ändern
    [Serializable]
    public class SpriteSet
    {
        public Sprite down;
        public Sprite left;
        public Sprite up;
        public Sprite right; //zusätzlich gespiegelt


        //Weist das Sprite zu welches in Blickrichtung passt
        public void Apply(SpriteRenderer spriteRenderer, int lookAt)
        {
            spriteRenderer.flipX = false;
            switch (lookAt)
            {
                case 0:
                    spriteRenderer.sprite = down;
                    break;
                case 1:
                    spriteRenderer.sprite = left;
                    break;
                case 2:
                    spriteRenderer.sprite = up;
                    break;
                case 3:
                    spriteRenderer.sprite = right;
                    spriteRenderer.flipX = true;
                    break;
            }
        }
    }
}
