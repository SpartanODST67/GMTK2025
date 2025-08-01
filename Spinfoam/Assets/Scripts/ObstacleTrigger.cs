using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger) return;

        if (collision.TryGetComponent(out NearMissTrigger nearMiss)) nearMiss.NearMiss = false;

        collision.gameObject.SetActive(false);
    }
}
