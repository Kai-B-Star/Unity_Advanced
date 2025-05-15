using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Declarations
    private bool isPaused;
    private UIManager uiManager;
    private int currentPoints;

    public static GameManager instance;

    public int CurrentPoints { get => currentPoints; set => currentPoints = value; }
    #endregion

    #region MonoBehaviour
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
        DontDestroyOnLoad(gameObject);
        PlantData plant = PlantSelectionManager.SelectedPlant;
    }
    private void Start()
    {
        uiManager = UIManager.instance;
        CurrentPoints = 0;
        isPaused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    #endregion
    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        uiManager.PauseGame();
    }  
    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        uiManager.Resume();
    }
    public void Restart()
    {
        CurrentPoints = 0;
        Time.timeScale = 1f;
        uiManager.Restart();
    }
    public void UpdatePoints(int points)
    {
        CurrentPoints += points;
        if(CurrentPoints >= 3)
        {
            uiManager.WinScreen();
        }
    }
}
