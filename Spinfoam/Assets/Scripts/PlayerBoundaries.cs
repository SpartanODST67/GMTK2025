using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    [SerializeField] Vector2 boundary = Vector3.one;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > boundary.x / 2)
        {
            transform.position = new Vector3(-boundary.x / 2, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -boundary.x / 2)
        {
            transform.position = new Vector3(boundary.x / 2, transform.position.y, transform.position.z);
        }

        if (transform.position.y > boundary.y / 2)
        {
            transform.position = new Vector3(transform.position.x, -boundary.y / 2, transform.position.z);
        }
        else if (transform.position.y < -boundary.y / 2)
        {
            transform.position = new Vector3(transform.position.x, boundary.y / 2, transform.position.z);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, boundary);
    }
}
