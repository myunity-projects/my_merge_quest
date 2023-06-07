using UnityEngine;

public static class Utils
{

    public static GameResources gameResources;

    public static GameResources InitResources()
    {
        Debug.Log("Resources initialized.");
        return gameResources = Resources.Load<GameResources>("GameResources");
    }

    public static Sprite GetWeaponsVisualById(int itemId)
    {
        return gameResources.weapon[itemId];
    }

    public static Sprite GetArmorVisualById(int itemId)
    {
        return gameResources.armor[itemId];
    }

    public static Sprite GetHealingVisualById(int itemId)
    {
        return gameResources.healing[itemId];
    }
}