using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameResources", menuName = "Items Container")]
public class GameResources : ScriptableObject 
{
    public List<Sprite> weapon = new List<Sprite>();
    public List<Sprite> armor = new List<Sprite>();
    public List<Sprite> healing = new List<Sprite>();
}