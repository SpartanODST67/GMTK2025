using UnityEngine;

public abstract class Boundaries : MonoBehaviour
{
    [SerializeField] protected Vector2 boundary = Vector3.one;

    public virtual void CheckBoundary()
    {
        if (transform.position.x > boundary.x / 2)
        {
            RightBoundaryAction();
        }
        else if (transform.position.x < -boundary.x / 2)
        {
            LeftBoundaryAction();
        }

        if (transform.position.y > boundary.y / 2)
        {
            UpperBoundaryAction();
        }
        else if (transform.position.y < -boundary.y / 2)
        {
            LowerBoundaryAction();
        }
    }

    protected abstract void UpperBoundaryAction();
    protected abstract void LowerBoundaryAction();
    protected abstract void RightBoundaryAction();
    protected abstract void LeftBoundaryAction();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, boundary);
    }
}
