using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
