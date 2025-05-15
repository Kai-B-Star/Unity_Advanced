using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlantSelectionManager
{
    public static PlantData SelectedPlant;
    private static int CurrentGrowthStage = 0;

    public static int CurrentGrowthStage1 { get => CurrentGrowthStage; set => CurrentGrowthStage = value; }

    public static void AdvanceGrowth()
    {
        if (SelectedPlant != null && CurrentGrowthStage1 < SelectedPlant.growthStages.Length - 1)
        {
            CurrentGrowthStage1++;
        }
    }
}
