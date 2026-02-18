using UnityEngine;

public class Gem : MonoBehaviour
{
    public void DoGemBehaviour()
    {
        Debug.Log("<color=cyan> SPARKEL SPARKLE SPARKEL </color>");
        GetComponent<SpriteRenderer>().color = Color.cyan;
    }
}
