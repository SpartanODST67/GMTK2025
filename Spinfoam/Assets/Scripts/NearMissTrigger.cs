using UnityEngine;

public class NearMissTrigger : MonoBehaviour
{
    private bool isNearMiss = false;
    public bool NearMiss
    {
        get { return isNearMiss; }
        set { isNearMiss = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isNearMiss = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        NearMissText.instance.NearMisses = 1;
        isNearMiss = false;
    }
}
