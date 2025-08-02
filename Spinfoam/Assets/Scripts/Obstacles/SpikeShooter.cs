using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShooter : Obstacle
{
    [SerializeField] Vector2 spinRange;
    [SerializeField] float spinSpeed;
    [SerializeField] float fireDelay = .5f;
    [SerializeField] List<SpikeObstacle> spikes; 

    private void Start()
    {
        Spawn();
    }

    public override void Spawn()
    {
        float targetAngle = Random.Range(spinRange.x, spinRange.y);
        StartCoroutine(Spin(targetAngle));
    }

    IEnumerator Spin(float targetAngle)
    {
        float currentAngle = 0;
        while(currentAngle < targetAngle)
        {
            currentAngle += spinSpeed * Time.deltaTime;
            Debug.Log(transform.localRotation);
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
