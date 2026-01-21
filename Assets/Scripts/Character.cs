using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    // Private variables
    [Header("Character Stats")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    private bool isDead = false;

    //Public properties
    public float MoveSpeed
    {
        // Read-only
        get { return moveSpeed; }
    }

    public bool IsDead
    {
        // Read-only
        get { return isDead; }
    }

    protected int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        // Level of Protection
        if(IsDead)
        {
            return;
        }

        CurrentHealth -= amount;
        Debug.Log($"{gameObject.name} HP is now: {CurrentHealth}");

        if(CurrentHealth <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        isDead = true;
        Debug.Log($"{gameObject.name} has died.");
    }
}
