using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSpawnerButton : MonoBehaviour
{
    GameController controller;

    string weaponSpriteType = "weapon";
    string armorSpriteType = "armor";
    string healingSpriteType = "healing";

    private void Start()
    {
        controller = FindObjectOfType<GameController>();
    }

    public void SpawnWeapon()
    {
        controller.PlaceRandomItem(weaponSpriteType);
    }

    public void SpawnArmor()
    {
        controller.PlaceRandomItem(armorSpriteType);
    }

    public void SpawnHealing()
    {
        controller.PlaceRandomItem(healingSpriteType);
    }
}
