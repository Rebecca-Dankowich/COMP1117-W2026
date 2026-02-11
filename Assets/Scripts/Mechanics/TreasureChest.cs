using UnityEngine;

public class TreasureChest : MonoBehaviour, IInteractable
{
    [Header("Loot Settings")]
    [SerializeField] private GameObject gemPrefab;      // "______Prefab" is convention
    [SerializeField] private int gemCount = 3;          // How many gem(s) get spewed from the chest
    [SerializeField] private float launchForce = 5f;    // Force behind launching gem(s)

    [Header("Visuals")]
    [SerializeField] private Sprite openChestSprite;    // Sprite for open chest

    private SpriteRenderer sRend;
    private bool isOpened = false;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>();       // Caching your reference
    }

    public void Interact()
    {
        // Saftey Check
        if(isOpened)
        {
            // If the chest is already open, do nothing and leave
            return;
        }

        // Chest is not opened
        isOpened = true;
        OpenChest();
    }

    private void OpenChest()
    {
        // 1. Change visual state to open
        // Saftey check
        if(sRend != null && openChestSprite != null)
        {
            sRend.sprite = openChestSprite;
        }
        // 2. Spew gems
        for(int i = 0; i < gemCount; i++)
        {
            GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity);
            Rigidbody2D gemRB = gem.GetComponent<Rigidbody2D>();

            // Saftey check
            if(gemRB != null )
            {
                // Launch it up in the air
                // Create a "fountain" effect
                Vector2 force = new Vector2(Random.Range(-1f, 1f), 1.5f).normalized * launchForce;
                gemRB.AddForce(force, ForceMode2D.Impulse);
            }
        }
    }
}
