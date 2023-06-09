using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
