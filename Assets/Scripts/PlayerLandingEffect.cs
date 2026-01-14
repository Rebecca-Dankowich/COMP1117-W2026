using UnityEngine;

public class PlayerLandingEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem landingParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            landingParticles.Play();
        }
    }
}