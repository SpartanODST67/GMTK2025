using UnityEngine;

public class NearMissTrigger : MonoBehaviour
{
    private bool isNearMiss = false;
    private bool isBlocked = false;
    public bool NearMiss
    {
        get { return isNearMiss; }
        set { isNearMiss = value; }
    }
    [SerializeField] int scorePerNearMiss = 100;
    [SerializeField] BulletTime bulletTime;
    [SerializeField] float timePerNearMiss = 5f;
    [SerializeField] AudioSource nearMissAudio;
    float nearMissAudioPitch;
    [SerializeField] Vector2 nearMissAudioPitchRange;

    private void Start()
    {
        nearMissAudioPitch = nearMissAudio.pitch;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBlocked || collision.gameObject == gameObject) return;
        isNearMiss = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isBlocked || collision.gameObject == gameObject) return;
        NearMissText.instance.NearMisses = 1;
        Scorekeeper.instance.AddScore(scorePerNearMiss);
        bulletTime.AddBulletTime(timePerNearMiss);
        nearMissAudio.pitch = nearMissAudioPitch * Random.Range(nearMissAudioPitchRange.x, nearMissAudioPitchRange.y);
        nearMissAudio.Play();
        isNearMiss = false;
    }

    public void BlockNearMiss()
    {
        isBlocked = true;
    }
}
