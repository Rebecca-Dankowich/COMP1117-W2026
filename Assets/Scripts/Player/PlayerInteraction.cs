using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private float interactRange = 1.5f;        //How close I must be to the interactable objects
    [SerializeField] private LayerMask interactableLayer;       // Ensure that I'm interacting with interactable objects

    // Function that will be called when the "interact" action is triggered
    public void OnInteract(InputAction.CallbackContext Context)
    {
        if (!Context.started) return;

        PerformInteraction();
    }
    
    private void PerformInteraction()
    {
        // Find everything in a circle around the player on the interactable layer
        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRange, interactableLayer);

        // Check if I hit something
        if(hit != null )
        {
            // Have hit something in the interactable layer
            // Safety first
            if (hit.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact();
                Debug.Log($"Interacted with {hit.name}");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
