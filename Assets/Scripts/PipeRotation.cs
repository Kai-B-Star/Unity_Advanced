using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRotation : MonoBehaviour
{
    #region Declarations
    [SerializeField] private PipeManager pipeManager;
    [SerializeField] private int rotationID;
    [SerializeField] private float[] correctID;
    private bool isCorrect = false;
    public int RotationID { get => rotationID; set => rotationID = value; }
    #endregion
    private void OnMouseDown()
    {
        if (RotationID == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            RotationID += 1;
        }
        else if (RotationID == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            RotationID += 1;
        }
        else if(RotationID == 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
            RotationID += 1;
        }
        else if(RotationID == 3)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            RotationID = 0;
        }

        if(RotationID == correctID[0] && isCorrect == false)
        {
            isCorrect = true;
            pipeManager.CorrectPipes();
        }
        else if(isCorrect == true)
        {
            isCorrect = false;
            pipeManager.WrongMove();
        }
    }
}
