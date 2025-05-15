using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer plantRenderer;
    void Start()
    {
        var plant = PlantSelectionManager.SelectedPlant;
        int stage = PlantSelectionManager.CurrentGrowthStage1;

        if (plant != null && stage < plant.growthStages.Length)
        {
            plantRenderer.sprite = plant.growthStages[stage];
        }
    }
}
