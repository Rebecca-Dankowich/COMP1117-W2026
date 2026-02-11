using UnityEngine;

public class NPCLogic : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject speechBubble;
    public void Interact()
    {
        // Safety check
        if(speechBubble == null)
        {
            // If speech bubble does not exist, return immediately and do nothing
            return;
        }

        // Speech bubble DOES exist
        bool isCurrentlyActive = speechBubble.activeSelf;

        speechBubble.SetActive(!isCurrentlyActive);
    }
}
