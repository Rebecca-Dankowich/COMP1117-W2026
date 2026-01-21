using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int damageToDeal = 5;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Requires that the game object colliding has the tag "Player"
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.TakeDamage(damageToDeal);
                Debug.Log("Player damaged by spikes");
            }
            else
            {
                Debug.LogWarning("HAZARD.CS: PlayerController is null");
            }
        }
    }
}
