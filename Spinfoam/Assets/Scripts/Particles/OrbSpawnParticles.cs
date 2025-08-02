using UnityEngine;

public class OrbSpawnParticles : MonoBehaviour
{
    [SerializeField] OrbObstacle orbObstacle;

    private void OnParticleSystemStopped()
    {
        orbObstacle.PostSpawn();
    }
}
