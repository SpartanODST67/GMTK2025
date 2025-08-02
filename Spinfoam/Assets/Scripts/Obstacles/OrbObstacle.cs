using System.Collections;
using UnityEngine;

public class OrbObstacle : Obstacle
{
    [SerializeField] Vector2 scaleRange;
    [SerializeField] Vector2 growthRateRange;
    [SerializeField] Vector2 lifetimeRange;
    [SerializeField] ParticleSystem spawnParticles;
    [SerializeField] GameObject despawnParticles;

    public override void Spawn()
    {
        transform.localScale = Vector3.zero;
        hitBox.enabled = false;
        spawnParticles.Play();
    }

    public void PostSpawn()
    {
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
            if(!hitBox.enabled && transform.localScale.x >= targetScale / 2) hitBox.enabled = true;
        }
        transform.localScale = Vector3.one * targetScale;

        float lifetime = Random.Range(lifetimeRange.x, lifetimeRange.y);
        Invoke(nameof(Despawn), lifetime);
    }

    public override void Despawn()
    {
        base.Despawn();
        Instantiate(despawnParticles, transform.position, despawnParticles.gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
