using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirt : PlayerBase
{
    #region Declarations
    private float spawnRate = 0.3f;
    [SerializeField] private GameObject rootPrefab;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float TeleportCheckDistance;
    [SerializeField] private LayerMask TeleportLayer;
    [SerializeField] private float CollisionCheckDistance;
    [SerializeField] private LayerMask CollisionLayer;
    #endregion
    private void Awake()
    {
        InvokeRepeating("CreateDirt", 0, spawnRate);
    }
    private void Update()
    {
        TeleportCheck();
        CollisionCheck();
        Move();
    }
    public void CreateDirt()
    {
        Instantiate(rootPrefab, transform.position + Vector3.up, transform.rotation);
    }
    public override void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        float xInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * xInput * speed * Time.deltaTime);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y);
    }
    private void TeleportCheck()
    {
        Debug.DrawRay(transform.position, Vector2.down * TeleportCheckDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, TeleportCheckDistance, TeleportLayer);

        if (hit)
        {
            float distanceY = 40;
            transform.position = new Vector2(transform.position.x, transform.position.y + distanceY);
        }
    }
    private void CollisionCheck()
    {
        Debug.DrawRay(transform.position, Vector2.down * CollisionCheckDistance, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, CollisionCheckDistance, CollisionLayer);

        if (hit)
        {
            gameManager.Restart();
        }
    }
}

