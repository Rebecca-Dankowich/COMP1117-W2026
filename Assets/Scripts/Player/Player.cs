using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputHandler), typeof(Rigidbody2D))]
public class Player : Character
{
    // Jumping Logic
    [Header("Movement Settings")]
    [SerializeField] private float jumpForce = 12f;             // The force of the jump
    [SerializeField] private LayerMask groundLayer;             // Checking to see if player is standing on ground layer
    [SerializeField] private Transform groundCheck;             // Position of the ground check
    [SerializeField] private float groundCheckRadius = 0.2f;    // Size of the ground check

    // Private Variables
    private Rigidbody2D rBody;          // Used to apply a force to move or jump
    private PlayerInputHandler input;   // Reads input
    private bool isGrounded;            // Holds the result of the ground check operation

    protected override void Awake()
    {
        base.Awake();
        //initialize
        rBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.Log(isGrounded);

        anim.SetFloat("xVelocity", Mathf.Abs(rBody.linearVelocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rBody.linearVelocity.y);

        // Handle Sprite Flipping
        if(input.MoveInput.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(input.MoveInput.x), 1, 1);
        }
    }

    void FixedUpdate()
    {
        if(IsDead)
        {
            return;
        }

        // Handle Movement
        HandleMovement();

        // Handle jumping
        HandleJump();
    }

    private void HandleMovement()
    {
        // We get MoveInput from InputHandler
        // We get MoveSpeed from our parent class (Character)

        float horizontalVelocity = input.MoveInput.x * MoveSpeed;

        rBody.linearVelocity = new Vector2(horizontalVelocity, rBody.linearVelocity.y);
    }

    private void HandleJump()
    {
        // Only jump if the input handles jump property is true
        if(input.JumpTriggered && isGrounded)
        {
            // Apply Jup force
            ApplyJumpForce();
            // "Consume the jump"
        }
    }

    private void ApplyJumpForce()
    {
        // Reset vertical velocity first to ensure consistent jump height
        rBody.linearVelocity = new Vector2(rBody.linearVelocity.x, 0);

        rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}