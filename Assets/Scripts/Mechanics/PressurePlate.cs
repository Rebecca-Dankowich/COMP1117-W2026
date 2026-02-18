using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private string keyTag = "HeavyKey";        // Tag to identify the correct key
    [SerializeField] private UnityEvent onActivated;

    private SpriteRenderer sRend;
    private bool isActivated = false;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>();                 // Caching the reference
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering is the Heavy Key
        if (other.CompareTag(keyTag) && !isActivated)
        {
            isActivated = true;

            Debug.Log("Heavy Key placed on pressure plate - Bridge Activated");

            // Trigger the Unity Event (activate Bridge)
            onActivated.Invoke();
        }
    }
}
