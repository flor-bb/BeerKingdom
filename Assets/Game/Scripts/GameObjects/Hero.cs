using UnityEngine;


//Hero Specific functions
public class Hero : TheGameObject
{
    private ContactFilter2D triggerContactFilter;
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
                foreach(Collectible collectible in foundCollider.GetComponents<Collectible>())
                {
                    collectible.OnCollect();
                }
            }
        }
    }





}
