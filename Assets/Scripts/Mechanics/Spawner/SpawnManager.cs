using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private EntitySpawner spawner;

    // Define what I want to spawn?
    public Gem gemPrefab;
    public Cherry cherryPrefab;

    // Two actions
    // Spawn Cherry
    public void OnSpawnCherry(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Cherry newCherry = spawner.Spawn<Cherry>(cherryPrefab, GetRandomPosition());
            newCherry.DoCherryBehaviour();
        }
    }
    // Spawn Gem
    public void OnSpawnGem(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Gem newGem = spawner.Spawn<Gem>(gemPrefab, GetRandomPosition());
            newGem.DoGemBehaviour();
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-5, 5), Random.Range(-2, 2), 0);
    }
}