using System.Collections;
using UnityEngine;

public class SpikeShooterSpawnParticle : MonoBehaviour
{
    [SerializeField] float spinSpeed = 90f;
    Coroutine spinCoroutine;
    [SerializeField] SpikeShooter spikeShooter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spinCoroutine = StartCoroutine(Spin());
    }

    void OnParticleSystemStopped()
    {
        StopCoroutine(spinCoroutine);
        spikeShooter.PostSpawn();
    }

    IEnumerator Spin()
    {
        while(true)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z + (spinSpeed * Time.deltaTime));
            yield return null;
        }
    }
}
