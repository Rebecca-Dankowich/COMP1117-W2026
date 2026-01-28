using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int damageToDeal = 5;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Requires that the game object colliding has the tag "Player"
        {
            Player playerController = collision.gameObject.GetComponent<Player>();

            if (playerController != null)
            {
                playerController.TakeDamage(damageToDeal);
                Debug.Log("Player damaged by spikes");
            }
            else
            {
                Debug.LogWarning("HAZARD.CS: Player is null");
            }
        }
    }
}
