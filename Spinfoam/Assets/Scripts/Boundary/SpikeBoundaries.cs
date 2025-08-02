using UnityEngine;

public class SpikeBoundaries : Boundaries
{
    protected override void LeftBoundaryAction()
    {
        Destroy(gameObject);
    }

    protected override void LowerBoundaryAction()
    {
        Destroy(gameObject);
    }

    protected override void RightBoundaryAction()
    {
        Destroy(gameObject);
    }

    protected override void UpperBoundaryAction()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        CheckBoundary();
    }
}
