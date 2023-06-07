using UnityEngine;

public class ItemInfo : MonoBehaviour 
{
    public int slotId;
    public int itemId;
    public string spriteType;

    public SpriteRenderer visualRenderer;

    public void InitDummy(int slotId, int itemId, string spriteType) 
    {
        this.slotId = slotId;
        this.itemId = itemId;
        this.spriteType = spriteType;

        switch (spriteType)
        {
            case "weapon":
                print("weapon created!");
                visualRenderer.sprite = Utils.GetWeaponsVisualById(itemId);
                break;
            case "armor":
                print("Armor created!");
                visualRenderer.sprite = Utils.GetArmorVisualById(itemId);
                break;
            case "healing":
                print("healing created!");
                visualRenderer.sprite = Utils.GetHealingVisualById(itemId);
                break;
        }
    }
}