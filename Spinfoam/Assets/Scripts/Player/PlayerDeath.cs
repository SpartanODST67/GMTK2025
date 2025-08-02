using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] ParticleSystem deathParticles;

    public void Die()
    {
        Instantiate(deathParticles.gameObject, transform.position, transform.rotation);
    }
}
