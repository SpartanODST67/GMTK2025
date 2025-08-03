using UnityEngine;

public class PlayerDeathSound : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;

    public void Play()
    {
        deathSound.Play();
    }
}
