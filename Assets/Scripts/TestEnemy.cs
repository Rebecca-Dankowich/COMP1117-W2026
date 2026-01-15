using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    [SerializeField] private int damageToDeal = 15;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Requires that the game object colliding has the tag "Player"
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>(); // gets the player controller based on what object that collided
            
            if (playerController != null)
            {
                playerController.TakeDamage(damageToDeal);
            }
            else
            {
                Debug.LogWarning("TESTENEMY.CS: PlayerController is null");
            }
        }
    }
}
