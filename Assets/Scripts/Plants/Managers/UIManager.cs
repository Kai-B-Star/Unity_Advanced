using System;
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

    public static UIManager instance;
    private GameManager gameManager;
    #endregion


    #region MonoBehavior
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        if (howToPlayMenu != null)
        howToPlayMenu.SetActive(false);
    }
    public enum Screens { Death, Win, Pause, Warning, HowToPlay, MainMenu, Seeds }

    private Dictionary<Screens, GameObject> screens;

    private void Start()
    {
        screens = new Dictionary<Screens, GameObject>();

        if (deathScreen != null) screens.Add(Screens.Death, deathScreen);
        if (winScreen != null) screens.Add(Screens.Win, winScreen);
        if (pauseMenu != null) screens.Add(Screens.Pause, pauseMenu);
        if (mainMenu != null) screens.Add(Screens.MainMenu, mainMenu);
        if (howToPlayMenu != null) screens.Add(Screens.HowToPlay, howToPlayMenu);
        if (warningScreen != null) screens.Add(Screens.Warning, warningScreen);
        if (seeds != null) screens.Add(Screens.Seeds, seeds);
    }
    #endregion
    private void ShowScreen(Screens type)
    {
        foreach (var screen in screens)
            screen.Value?.SetActive(false);

        screens[type]?.SetActive(true);
    }
    public void DeathScreen()
    {
        ShowScreen(Screens.Death);
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
        ShowScreen(Screens.Seeds);
    }
    public void Restart()
    {
        Destroy(UIManager.instance.gameObject);
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

    private void OnEnable()
    {
        GameManager.OnDeath += DeathScreen;
        GameManager.OnGameWin += WinScreen;
    }
    private void OnDisable()
    {
        GameManager.OnDeath -= DeathScreen;
        GameManager.OnGameWin -= WinScreen;
    }
}
