using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public Slot parentSlot;
    public string spriteType;

    public SpriteRenderer visualRenderer;

    public void Init(int id, Slot slot, string spriteType)
    {
        this.id = id;
        this.parentSlot = slot;
        this.spriteType = spriteType;

        switch(spriteType)
        {
            case "weapon":
                visualRenderer.sprite = Utils.GetWeaponsVisualById(id);
                break;
            case "armor":
                visualRenderer.sprite = Utils.GetArmorVisualById(id);
                break;
            case "healing":
                visualRenderer.sprite = Utils.GetHealingVisualById(id);
                break;
        }
    }
        
}
