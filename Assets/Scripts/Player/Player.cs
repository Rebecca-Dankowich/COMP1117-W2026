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
    private Rigidbody2D rBody;                  // Used to apply a force to move or jump
    private PlayerInputHandler input;           // Reads input
    private bool isGrounded;                    // Holds the result of the ground check operation
    private float currentSpeedModifier = 1f;    // Used within WaterZone
    private float defaultGravityScale;
    private float currentGravityModifier = 1f;
    private bool isFalling;

    protected override void Awake()
    {
        base.Awake();
        //initialize
        rBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();

        defaultGravityScale = rBody.gravityScale;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.Log(isGrounded);

        anim.SetFloat("xVelocity", Mathf.Abs(rBody.linearVelocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isFalling", isFalling);               // Allows for falling animation to play independently of the y velocity

        float yVelocity = rBody.linearVelocity.y;

        //Falling means moving towards the ground
        if (rBody.gravityScale > 0)
        {
            // Normal gravity: Falling downwards
            isFalling = yVelocity < 0f && !isGrounded;
        }
        else
        {
            // Inverted gravity: falling upwards
            isFalling = yVelocity > 0f && !isGrounded;
        }

        // Handle Sprite Flipping
        if (input.MoveInput.x != 0 && !isDead)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(input.MoveInput.x);
            transform.localScale = scale;
        }
    }

    void FixedUpdate()
    {
        if(IsDead)
        {
            return;
        }

        ApplyGravity();

        // Handle Movement
        HandleMovement();

        // Handle jumping
        HandleJump();
    }

    private void HandleMovement()
    {
        // We get MoveInput from InputHandler
        // We get MoveSpeed from our parent class (Character)

        float horizontalVelocity = input.MoveInput.x * MoveSpeed * currentSpeedModifier;

        rBody.linearVelocity = new Vector2(horizontalVelocity, rBody.linearVelocity.y);
        
        currentSpeedModifier = 1f;
    }

    private void HandleJump()
    {
        // Only jump if the input handles jump property is true
        if(input.JumpTriggered && isGrounded)
        {
            // Apply Jump force
            ApplyJumpForce();
            // "Consume the jump"
        }
    }

    private void ApplyJumpForce()
    {
        // Reset vertical velocity first to ensure consistent jump height
        rBody.linearVelocity = new Vector2(rBody.linearVelocity.x, 0);

        Vector2 jumpDirection = rBody.gravityScale > 0 ? Vector2.up : Vector2.down; // Adjust jump direction depending on gravity orientation

        rBody.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
    }

    public void ApplySpeedModifier(float speedModifier)
    {
        currentSpeedModifier = speedModifier;
    }

    public override void Die()
    {
        isDead = true;
        Debug.Log("Player has died");

        // PLAYER DEATH LOGIC
        // ===================
        // Add player specific death logic
        // Set death animation
        // Trigger death UI
        // Initiate level reset logic
    }

    private void ApplyGravity()
    {
        rBody.gravityScale = defaultGravityScale * currentGravityModifier;

        // Flip sprite vertically if gravity is inverted
        Vector3 scale = transform.localScale;
        float y = currentGravityModifier < 0 ? -Mathf.Abs(scale.y) : Mathf.Abs(scale.y);
        transform.localScale = new Vector3(scale.x, y, scale.z);

        // Reset for next frame
        currentGravityModifier = 1f;
    }

    public void ApplyGravityModifier(float gravityModifier)
    {
        currentGravityModifier = gravityModifier;
    }
}