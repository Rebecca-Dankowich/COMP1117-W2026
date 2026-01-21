using UnityEngine;

public class PlayerLandingEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem landingParticles;

    private bool wasGrounded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !wasGrounded)
        {
            landingParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            landingParticles.Play();
            
            wasGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            wasGrounded = false;
        }
    }
}