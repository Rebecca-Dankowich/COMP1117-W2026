using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class HomingGem : MonoBehaviour
{
    [Header("Homing Settings")]
    [SerializeField] private float hoverDuration = 0.5f;        // How long the gem will hover for
    [SerializeField] private float homingSpeed = 8f;            // Speed when moving towards the player
    [SerializeField] private float collectionDistance = 0.5f;   // Distance at which the gem is collected/disappears

    private Transform player;
    private Rigidbody2D rb;
    private bool isHoming = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Find the player based on the tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        StartCoroutine(HomingSequence());
    }

    private IEnumerator HomingSequence()
    {
        // Step 1: Wait for the hover duration while the gem is launched
        yield return new WaitForSeconds(hoverDuration);

        // Step 2: Stop physics based movement and switch to homing
        if(rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 0f;                           // Disable gravity
            rb.bodyType = RigidbodyType2D.Kinematic;        // Make kinematic to have full control
        }

        isHoming = true;
    }

    private void Update()
    {
        if (isHoming && player != null)
        {
            // Move towards the player
            Vector2 currentPosition = transform.position;
            Vector2 targetPosition = player.position;

            // Calculate distance to player
            float distanceToPlayer = Vector2.Distance(currentPosition, targetPosition);

            // Move towards player at constant speed
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, homingSpeed * Time.deltaTime);

            transform.position = newPosition;

            // Check if we've reached the player
            if (distanceToPlayer < collectionDistance)
            {
                // Destroy the gem when it reaches the player
                Destroy(gameObject);
                return;
            }

            

        }
    }
}
