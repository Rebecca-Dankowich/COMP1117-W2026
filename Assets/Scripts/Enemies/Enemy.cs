using UnityEngine;

public class Enemy : Character
{
    [Header("Enemy Settings")]
    [SerializeField] private float patrolDistance = 5.0f;

    private Vector2 startPos;       // Starting Position
    private int direction = -1;      // Direction the enemy is facing

    protected override void Awake()
    {
        base.Awake();
        startPos = transform.position;
    }

    private void Update()
    {
        // Calculate the boundaries of the movement
        float leftBoundary = startPos.x - patrolDistance;
        float rightBoundary = startPos.x + patrolDistance;

        // Move the Enemy
        transform.Translate(Vector2.right * direction * MoveSpeed * Time.deltaTime);

        // Flip the enemy when it hits a boundary
        if (transform.position.x >= rightBoundary)
        {
            direction = -1;     // Go to the left
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (transform.position.x <= leftBoundary)
        {
            direction = 1;      // Go to the right
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }
}
