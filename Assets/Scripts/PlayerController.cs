using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerStats stats;

    //Components
    private Rigidbody2D rBody;

    //Field Variables
    private Vector2 moveInput;

    void Awake()
    {
        //initialize
        rBody = GetComponent<Rigidbody2D>();
        stats = new PlayerStats();
        int something = stats.MoveSpeed;
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
        float velocityX = moveInput.x;
        rBody.linearVelocity = new Vector2(velocityX * stats.MoveSpeed, rBody.linearVelocity.y);
    }

}
