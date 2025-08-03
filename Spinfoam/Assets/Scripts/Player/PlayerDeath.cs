using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] PlayerDeathSound deathSound;

    public void Die()
    {
        Instantiate(deathParticles.gameObject, transform.position, transform.rotation);
        Scorekeeper.instance.StopScoredTime();
        Scorekeeper.instance.SaveHighScore();
        ObstacleSpawner.instance.StopSpawning();
        MainMenu.instance.OpenMenu();
        deathSound.Play();

        gameObject.SetActive(false);
    }
}
