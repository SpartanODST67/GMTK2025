using UnityEngine;

public class MatchTransform : MonoBehaviour
{
    [SerializeField] Transform copyTransform;
    [SerializeField] Vector3 offset;

    private void Update()
    {
        transform.position = copyTransform.position + offset;
        transform.rotation = copyTransform.rotation;
    }
}
