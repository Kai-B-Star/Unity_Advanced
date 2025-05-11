using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Nutrient : MonoBehaviour, ICollectable
{
    private GameManager manager;
    public UnityEvent OnCollect;

    private void Start()
    {
        manager = GameManager.instance;
    }
      
    public void Collect()
    {
        OnCollect.Invoke();
        manager.UpdatePoints(1);
        Destroy(gameObject);
    }
}
