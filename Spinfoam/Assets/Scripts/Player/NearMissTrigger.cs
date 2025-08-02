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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBlocked || collision.gameObject == gameObject) return;
        isNearMiss = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isBlocked || collision.gameObject == gameObject) return;
        NearMissText.instance.NearMisses = 1;
        isNearMiss = false;
    }

    public void BlockNearMiss()
    {
        isBlocked = true;
    }
}
