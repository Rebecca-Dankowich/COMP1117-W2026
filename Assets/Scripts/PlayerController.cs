using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Initial Player Stats")]
    // Initial Player Stats
    [SerializeField] private float initialSpeed = 5;

    // Private Variables
    private PlayerStats stats;
    private Vector2 moveInput;

    //Components
    private Rigidbody2D rBody;

    void Awake()
    {
        //initialize
        rBody = GetComponent<Rigidbody2D>();

        stats = new PlayerStats();
        stats.MoveSpeed = initialSpeed;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    void ApplyMovement()
    {
        float velocityX = moveInput.x * stats.MoveSpeed;

        rBody.linearVelocity = new Vector2(velocityX * stats.MoveSpeed, rBody.linearVelocity.y);
    }

}
