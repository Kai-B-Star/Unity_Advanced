using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Nutrient : MonoBehaviour, ICollectable
{
    private GameManager manager;

    private void Start()
    {
        manager = GameManager.instance;
    }
      
    public void Collect()
    {
        manager.UpdatePoints(1);
        Destroy(gameObject);
    }
}
