using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Variable to control how quickly the camera will follow the player
    private float smoothTime = 0.2f;

    // Variable to store the current velocity of the camera
    private Vector3 velocity = Vector3.zero;

    public float SmoothTime
    {
        get 
        { 
            return smoothTime; 
        }
        set 
        { 
            // prevents smoothTime from being </= 0
            smoothTime = Mathf.Max(0.01f, value); 
        }
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        Vector3 targetPosition = new Vector3
            (
                player.position.x,
                player.position.y,
                transform.position.z //Keeps the camera's Z position unchanged
            );

        transform.position = Vector3.SmoothDamp
            (
                transform.position,     // Current Camera position
                targetPosition,         // Desired position
                ref velocity,           // Current velocity
                smoothTime              // Time it takes to reach the target
            );
    }
}