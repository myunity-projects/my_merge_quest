using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameResources", menuName = "Items Container")]
public class GameResources : ScriptableObject 
{
    public List<Sprite> items = new List<Sprite>();
}