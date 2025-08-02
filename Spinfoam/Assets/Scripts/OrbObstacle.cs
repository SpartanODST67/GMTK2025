using System.Collections;
using UnityEngine;

public class OrbObstacle : Obstacle
{
    [SerializeField] Vector2 scaleRange;
    [SerializeField] Vector2 growthRateRange;
    [SerializeField] Vector2 lifetimeRange;

    public override void Spawn()
    {
        transform.localScale = Vector3.zero;   
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        float targetScale = Random.Range(scaleRange.x, scaleRange.y);
        float growthRate = Random.Range(growthRateRange.x, growthRateRange.y);
        while(transform.localScale.x < targetScale)
        {
            yield return null;
            Vector3 nextScale = Vector3.Lerp(transform.localScale, Vector3.one * targetScale, growthRate);
            transform.localScale += nextScale * Time.deltaTime;
        }
        transform.localScale = Vector3.one * targetScale;

        float lifetime = Random.Range(lifetimeRange.x, lifetimeRange.y);
        Invoke(nameof(Despawn), lifetime);
    }

    public override void Despawn()
    {
        base.Despawn();
        Destroy(gameObject);
    }
}
