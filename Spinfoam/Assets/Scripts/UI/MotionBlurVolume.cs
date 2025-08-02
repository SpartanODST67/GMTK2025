using UnityEngine;
using UnityEngine.Rendering;

public class MotionBlurVolume : MonoBehaviour
{
    public static MotionBlurVolume instance;
    [SerializeField] Volume motionBlurVolume;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ActivateVolume()
    {
        motionBlurVolume.enabled = true;
    }

    public void DeactivateVolume()
    {
        motionBlurVolume.enabled = false;
    }
}
