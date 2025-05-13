using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    #region Declarations
    [SerializeField] private int correctPipes;
    [SerializeField] private GameObject interactablePipes;
    [SerializeField] private GameObject[] Pipes;
    [SerializeField] private int totalPipes = 0;
    private bool winActive;
    public bool WinActive { get => winActive; set => winActive = value; }
    #endregion
    private void Start()
    {
        totalPipes = interactablePipes.transform.childCount;
        Pipes = new GameObject[totalPipes];
        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = interactablePipes.transform.GetChild(i).gameObject;
        }
        WinActive = false;
    }
    public void CorrectPipes()
    {
        correctPipes += 1;
        if(correctPipes == totalPipes)
        {
            WinActive = true;
        }
        else
        {
            WinActive = false;
        }
    }
    public void WrongMove()
    {
        correctPipes -= 1;
    }
}
