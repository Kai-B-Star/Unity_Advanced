using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Declarations
    [Header("UI Panels")]
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject howToPlayMenu;
    [SerializeField] private GameObject warningScreen;
    [SerializeField] private GameObject seeds;
    public enum Screens { Death, Win, Pause, Warning, HowToPlay, MainMenu, Seeds }
    private Dictionary<Screens, GameObject> screenOrganize;

    public static UIManager instance;
    #endregion

    #region MonoBehavior
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if(howToPlayMenu != null)
        howToPlayMenu.SetActive(false);
    }
    private void Start()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(false);

        if (deathScreen != null)
            deathScreen.SetActive(false);

        if (winScreen != null)
            winScreen.SetActive(false);

        if(warningScreen != null) 
            warningScreen.SetActive(false);

        GameManager.OnMinigameComplete += HandleMinigameComplete;
        GameManager.OnDeath += HandleDeath;
       
        screenOrganize = new Dictionary<Screens, GameObject>();
        screenOrganize.Add(Screens.Death, deathScreen);
        screenOrganize.Add(Screens.Win, winScreen);
        screenOrganize.Add(Screens.Pause, pauseMenu);
        screenOrganize.Add(Screens.Warning, warningScreen);
        screenOrganize.Add(Screens.HowToPlay, howToPlayMenu);
        screenOrganize.Add(Screens.MainMenu, mainMenu);
        screenOrganize.Add(Screens.Seeds, seeds);
    }
    #endregion
    public void ShowScreen(Screens screenType)
    {
        foreach (var screen in screenOrganize.Values)
        {
            if (screen != null) screen.SetActive(false);
        }

        if (screenOrganize.ContainsKey(screenType) && screenOrganize[screenType] != null)
        {
            screenOrganize[screenType].SetActive(true);
        }
    }
    private void HandleDeath()
    {
        DeathScreen();
    }
    private void HandleMinigameComplete()
    {
        WinScreen();
    }
    public void DeathScreen()
    {
        ShowScreen(Screens.Death);
        warningScreen.SetActive(false);
        Time.timeScale = 0f;
    }
    public void WinScreen()
    {
        ShowScreen(Screens.Win);
        warningScreen.SetActive(false);
        Time.timeScale = 0f;
    }
    public void WarningScreen()
    {
        ShowScreen(Screens.Warning);
        if(pauseMenu != null)
        pauseMenu.SetActive(false);
        if(deathScreen != null)
        deathScreen.SetActive(false);
        if(winScreen != null)
        winScreen.SetActive(false);
    }
    public void PauseGame()
    {
        ShowScreen(Screens.Pause);
        warningScreen.SetActive(false);
        if(seeds != null)
        seeds.SetActive(false);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        if(seeds != null)
        seeds.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void HowToPlay()
    {
        ShowScreen(Screens.HowToPlay);
        mainMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    } 
}
