using UnityEngine;

public class Kickstarter : MonoBehaviour
{
    [SerializeField] Starter starter;

    private void Awake()
    {
        starter.KickStart();    
    }
}
