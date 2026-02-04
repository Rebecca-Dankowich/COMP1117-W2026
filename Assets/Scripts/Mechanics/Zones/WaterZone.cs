using UnityEngine;
using UnityEngine.Windows;

public class WaterZone : Zone
{
    [SerializeField] private float speedModifier = 0.5f;
    // Reduce the player speed by half
    protected override void ApplyZoneEffect(Player player)
    {
        // Check my player's speed modifier value
        player.ApplySpeedModifier(speedModifier);
    }
}
