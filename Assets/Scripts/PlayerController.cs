using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Initial Player Stats")]
    // Initial Player Stats
    [SerializeField] private float initialSpeed = 5;
    [SerializeField] private int initialHealth = 100;

    // Private Variables
    private PlayerStats stats;
    private Vector2 moveInput;
    private bool hasLoggedDeath = false;

    //Components
    private Rigidbody2D rBody;

    void Awake()
    {
        //initialize
        rBody = GetComponent<Rigidbody2D>();

        stats = new PlayerStats(initialSpeed, initialHealth);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        float velocityX = moveInput.x * stats.MoveSpeed;

        rBody.linearVelocity = new Vector2(velocityX, rBody.linearVelocity.y);
    }

    public void TakeDamage(int damageAmount)
    {
        if (IsDead) return; //Prevents further damage if already dead

        stats.CurrentHealth -= damageAmount;

        //Check if player is dead
        bool dead = IsDead;

        if (IsDead)
        {
            HandleDeath();
        }
    }

    //Derived Property for death
    public bool IsDead
    {
        get
        {
            return stats.CurrentHealth <= 0;
        }
    }

    // Handles death logic
    private void HandleDeath()
    {
        if (!hasLoggedDeath)
        {
            Debug.Log("Player has perished");
            hasLoggedDeath = true;
        }
    }
}
