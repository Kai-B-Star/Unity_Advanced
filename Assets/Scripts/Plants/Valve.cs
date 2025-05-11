using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    [SerializeField] private PipeManager pipe;
 
    public static event Action OnValveSuccess;
    public static event Action OnValveFailure;

    private void OnMouseDown()
    {
        if (pipe != null && pipe.WinActive)
        {
            OnValveSuccess?.Invoke();
        }
        else
        {
            OnValveFailure?.Invoke();
        }
    }
}
