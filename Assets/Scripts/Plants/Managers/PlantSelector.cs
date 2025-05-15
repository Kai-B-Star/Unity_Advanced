using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantSelector: MonoBehaviour
{
    public void OnPlantSelected(PlantData chosenPlant)
    {
        PlantSelectionManager.SelectedPlant = chosenPlant;
        SceneManager.LoadScene("PlantGrowth");
    }
}
