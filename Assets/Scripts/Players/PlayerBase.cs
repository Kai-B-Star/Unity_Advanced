using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    #region Declarations
    protected int speed = 2;
    protected UIManager uiManager;
    [SerializeField] protected GameManager gameManager;
    #endregion
    private void Awake()
    {
        uiManager = UIManager.instance;
        gameManager = GameManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectable collectable = collision.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
        }
    }
    public virtual void Move()
    { }   
}
