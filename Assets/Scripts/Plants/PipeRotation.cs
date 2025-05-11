using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PipeRotation : MonoBehaviour
{
    #region Declarations
    [SerializeField] private PipeManager pipeManager;
    [SerializeField] private int rotationID;
    [SerializeField] private float[] correctID;
    private bool isCorrect = false;
    #endregion
    public int RotationID
    {
        get => rotationID;
        set
        {
            rotationID = value % 4;
            transform.rotation = Quaternion.Euler(0, 0, rotationID * 90);
        }
    }
    private void OnMouseDown()
    {
        RotationID++;
        bool wasCorrect = isCorrect;
        isCorrect = correctID.Contains(rotationID); 

        if (isCorrect && !wasCorrect)
        {
            pipeManager.CorrectPipes();
        }
        else if (!isCorrect && wasCorrect)
        {
            pipeManager.WrongMove();
        }
    }
}
