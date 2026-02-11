using UnityEngine;
using UnityEngine.Events;

public class WorldSwitch : MonoBehaviour
{
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private UnityEvent onActivated;

    private SpriteRenderer sRend;
    private bool isFlipped = false;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>(); // Chaching the reference
    }

    public void Interact()
    {
        isFlipped = !isFlipped; // Flips the boolean value

        sRend.sprite = isFlipped ? offSprite : onSprite;

        if(isFlipped)
        {
            onActivated.Invoke();
        }
    }
}
