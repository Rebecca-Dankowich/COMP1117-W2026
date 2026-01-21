using UnityEngine;
using UnityEngine.InputSystem;

// Read input from the input system.
public class PlayerInputHandler : MonoBehaviour
{
    // What inputs can my player do right  now.
    // 1. Move left and right
    // 2. Jump

    private Vector2 moveInput; // Left and right movement
    private bool jumpTriggered = false; // Jumping?

    //Public Properties to read input values
    public Vector2 MoveInput
    {
        // Read-only
        get {  return moveInput; }
    }

    public bool JumpTriggered
    {
        // Read-only
        get { return jumpTriggered; }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Save input to the field
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started) // Started to press button
        {
            jumpTriggered = true;
        }
        else if(context.canceled) // Let go of button
        {
            jumpTriggered = false;
        }
    }
}
