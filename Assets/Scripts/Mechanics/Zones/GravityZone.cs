using UnityEngine;
using UnityEngine.Windows;

public class GravityZone : Zone
{
    protected override void ApplyZoneEffect(Player player)
    {
        player.ApplyGravityModifier(-1f);
    }
}