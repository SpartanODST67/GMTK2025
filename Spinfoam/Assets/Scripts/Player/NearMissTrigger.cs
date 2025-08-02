using UnityEngine;

public class NearMissTrigger : MonoBehaviour
{
    private bool isNearMiss = false;
    private bool isBlocked = false;
    public bool NearMiss
    {
        get { return isNearMiss; }
        set { isNearMiss = value; }
    }
    [SerializeField] int scorePerNearMiss = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBlocked || collision.gameObject == gameObject) return;
        isNearMiss = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isBlocked || collision.gameObject == gameObject) return;
        NearMissText.instance.NearMisses = 1;
        Scorekeeper.instance.AddScore(scorePerNearMiss);
        isNearMiss = false;
    }

    public void BlockNearMiss()
    {
        isBlocked = true;
    }
}
