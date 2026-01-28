using UnityEngine;

public class PlayerStats
{
    private float moveSpeed;
    private int maxHealth;
    private int currentHealth;
    
    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            if (value > 20)
            {
                moveSpeed = 20;
            }
            else if (value < 0)
            {
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = value;
            }
        }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = Mathf.Clamp(value, 0, MaxHealth);
            Debug.Log($"Player Health: {currentHealth}");
        }
    }

    // Constructor
    // Default constructor -- no parameters
    public PlayerStats()
    {
        moveSpeed = 10;
        maxHealth = 100;
        currentHealth = 100;
    }

    public PlayerStats(float moveSpeed, int maxHealth)
    {
        this.moveSpeed = moveSpeed;
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;

        Debug.Log($"Player initialized with MoveSpeed = {moveSpeed}, MaxHealth = {maxHealth}, CurrentHealth = {currentHealth}");
    }
}
