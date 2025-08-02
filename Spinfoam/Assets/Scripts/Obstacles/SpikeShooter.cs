using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShooter : Obstacle
{
    [SerializeField] Vector2 spinRange;
    [SerializeField] float spinSpeed;
    [SerializeField] float fireDelay = .5f;
    [SerializeField] List<SpikeObstacle> spikes;
    [SerializeField] ParticleSystem spawnParticle;

    public override void Spawn()
    {
        foreach(SpikeObstacle spike in spikes)
        {
            spike.gameObject.SetActive(false);
        }
        spawnParticle.Play();
    }

    public void PostSpawn()
    {
        foreach(SpikeObstacle spike in spikes)
        {
            spike.gameObject.SetActive(true);
        }

        float targetAngle = Random.Range(spinRange.x, spinRange.y);
        StartCoroutine(Spin(targetAngle));
    }

    IEnumerator Spin(float targetAngle)
    {
        float currentAngle = 0;
        while(currentAngle < targetAngle)
        {
            currentAngle += spinSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 0, currentAngle);
            yield return null;
        }
        transform.localRotation = Quaternion.Euler(0, 0, targetAngle);
        Invoke(nameof(Fire), fireDelay);
    }

    private void Fire()
    {
        foreach(SpikeObstacle spike in spikes)
        {
            spike.Spawn();
        }
        Despawn();
    }

    public override void Despawn()
    {
        base.Despawn();
        Destroy(gameObject);
    }
}
