using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    [SerializeField] private PipeManager pipe;
    private UIManager uiManager;

    private void Start()
    {
      uiManager = UIManager.instance;
    }
    private void OnMouseDown()
    {
        if (pipe != null && pipe.WinActive)
        {
            uiManager.WinScreen();
        }
        else
        {
            uiManager.DeathScreen();
        }
    }
}
