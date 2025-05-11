using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantSceneManager: MonoBehaviour
{
    #region Sunflower Scenes
    public void Plant1()
    {
        SceneManager.LoadScene("Plant1");
    }
    public void Plant2()
    {
        SceneManager.LoadScene("Plant2");
    }
    public void Plant3()
    {
        SceneManager.LoadScene("Plant3");
    }
    public void Plant4()
    {
        SceneManager.LoadScene("Plant4");
    }
    #endregion

    #region Carnivore Scenes
    public void PPlant1()
    {
        SceneManager.LoadScene("Plant1.1");
    }
    public void PPlant2()
    {
        SceneManager.LoadScene("Plant2.2");
    }
    public void PPlant3()
    {
        SceneManager.LoadScene("Plant3.3");
    }
    public void PPlant4()
    {
        SceneManager.LoadScene("Plant4.4");
    }
    #endregion

    #region Suculent Scenes
    public void PPPlant1()
    {
        SceneManager.LoadScene("Plant1.1.1");
    }
    public void PPPlant2()
    {
        SceneManager.LoadScene("Plant2.2.2");
    }
    public void PPPlant3()
    {
        SceneManager.LoadScene("Plant3.3.3");
    }
    public void PPPlant4()
    {
        SceneManager.LoadScene("Plant4.4.4");
    }
    #endregion

    #region Minigames
    public void WaterLevel1()
    {
        SceneManager.LoadScene("Water1");
    }
    public void WaterLevel2()
    {
        SceneManager.LoadScene("Water2");
    }
    public void WaterLevel3()
    {
        SceneManager.LoadScene("Water3");
    }
    public void NutrientLevel1()
    {
        SceneManager.LoadScene("Nutrients1");
        Time.timeScale = 1f;
    }
    public void NutrientLevel2()
    {
        SceneManager.LoadScene("Nutrients2");
        Time.timeScale = 1f;
    }
    public void NutrientLevel3()
    {
        SceneManager.LoadScene("Nutrients3");
        Time.timeScale = 1f;
    }
    public void SunLevel1()
    {
        SceneManager.LoadScene("Sun1");
        Time.timeScale = 1f;
    }
    public void SunLevel2()
    {
        SceneManager.LoadScene("Sun2");
        Time.timeScale = 1f;
    }
    public void SunLevel3()
    {
        SceneManager.LoadScene("Sun3");
        Time.timeScale = 1f;
    }
    #endregion

    public void SeedPicker()
    {
        SceneManager.LoadScene("SeedPick");
    }
  
}
