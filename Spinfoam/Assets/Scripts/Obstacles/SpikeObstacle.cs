using UnityEngine;

public class SpikeObstacle : Obstacle
{
    [SerializeField] float speed = 5f;
    bool isFired = false;


    private void Update()
    {
        if (!isFired) return;
        transform.localPosition += transform.up * speed * Time.deltaTime;    
    }

    public override void Spawn()
    {
        transform.SetParent(null);
        isFired = true;
    }
}
