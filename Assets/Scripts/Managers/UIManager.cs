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
        gameManager = GameManager.instance;
        if (pauseMenu != null)
            pauseMenu.SetActive(false);

        if (deathScreen != null)
            deathScreen.SetActive(false);

        if (winScreen != null)
            winScreen.SetActive(false);

        if(warningScreen != null) 
            warningScreen.SetActive(false);

    }
    #endregion

    public void DeathScreen()
    {
        deathScreen.SetActive(true);
        warningScreen.SetActive(false);
        Time.timeScale = 0f;
    }
    public void WinScreen()
    {
        winScreen.SetActive(true);
        warningScreen.SetActive(false);
        Time.timeScale = 0f;
    }
    public void WarningScreen()
    {
        warningScreen.SetActive(true);
        if(pauseMenu != null)
        pauseMenu.SetActive(false);
        if(deathScreen != null)
        deathScreen.SetActive(false);
        if(winScreen != null)
        winScreen.SetActive(false);
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
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
        howToPlayMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    
}
