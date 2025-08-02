using UnityEngine;

public class PlayerBoundaries : Boundaries
{
    protected override void LeftBoundaryAction()
    {
        transform.position = new Vector3(boundary.x / 2, transform.position.y, transform.position.z);
    }

    protected override void LowerBoundaryAction()
    {
        transform.position = new Vector3(transform.position.x, boundary.y / 2, transform.position.z);
    }

    protected override void RightBoundaryAction()
    {
        transform.position = new Vector3(-boundary.x / 2, transform.position.y, transform.position.z);
    }

    protected override void UpperBoundaryAction()
    {
        transform.position = new Vector3(transform.position.x, -boundary.y / 2, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        CheckBoundary();
    }
}
