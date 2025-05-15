using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSun : PlayerBase
{
    #region Declarations
    private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;
    private SpriteRenderer spriteRenderer;
    private UIManager manager;
    private bool isGrounded;
    private float movementSpeed = 8;
    private float jumpForce = 10;
    private float groundCheckDistance = 1.5f;
    [SerializeField] private LayerMask groundLayer;

    public LayerMask GroundLayer { get => groundLayer; set => groundLayer = value; }
    #endregion
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        manager = UIManager.instance;
    }
    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        rigidBody.velocity = new Vector2(horizontalInput * movementSpeed, rigidBody.velocity.y);
        Jump();
        GroundCheck();

        animator.SetFloat("MoveSpeed", Mathf.Abs(horizontalInput));
        animator.SetBool("IsGrounded", isGrounded);

        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    private void GroundCheck()
    {
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, GroundLayer);
        isGrounded = hit;

        if (hit)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            animator.SetTrigger("Jump");
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
