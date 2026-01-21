using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGER ENTER: " + other.name);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("TRIGGER STAY: " + other.name);
    }
}
