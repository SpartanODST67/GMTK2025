using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] protected Collider2D hitBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerHitEvent(collision);
    }

    public virtual void TriggerHitEvent(Collider2D collision)
    {
        if (collision.isTrigger) return;

        if (collision.TryGetComponent(out NearMissTrigger nearMiss))
        {
            nearMiss.NearMiss = false;
            nearMiss.BlockNearMiss();
        }

        collision.gameObject.SetActive(false);
    }

    public abstract void Spawn();

    public virtual void Despawn()
    {
        if(ObstacleSpawner.instance != null) ObstacleSpawner.instance.RemoveObstacle();
    }
}
