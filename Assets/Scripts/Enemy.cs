using UnityEngine;

public class Enemy : Character
{
    [Header("Enemy Settings")]
    [SerializeField] private float patrolDistance = 5.0f;

    protected override void Awake()
    {
        base.Awake();
    }
}
