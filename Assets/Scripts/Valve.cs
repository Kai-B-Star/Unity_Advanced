using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    #region Declarations
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private PipeManager pipe;
    #endregion
    private void Start()
    {
        gameManager = GameManager.instance;
        uiManager = UIManager.instance;
    }
    private void OnMouseDown()
    {
       if(pipe.WinActive == true)
        {
            gameManager.UpdatePoints(3);
        }
        else
        {
            uiManager.DeathScreen();
        }
    }
}
