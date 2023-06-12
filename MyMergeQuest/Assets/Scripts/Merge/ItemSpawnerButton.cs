using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerButton : MonoBehaviour
{
    GameController controller;

    private void Start()
    {
        controller = FindObjectOfType<GameController>();
    }

    public void SpawnWeapon()
    {
        controller.PlaceRandomItem();
    }
}
