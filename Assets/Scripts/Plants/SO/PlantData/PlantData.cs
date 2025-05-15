using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Plant")]
public class PlantData : ScriptableObject
{
    public string plantName;
    public Sprite[] growthStages; // index 0 = seed, 1 = sprout, 2 = plant, 3 = flower
}
