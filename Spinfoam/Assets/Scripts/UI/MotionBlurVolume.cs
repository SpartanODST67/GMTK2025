using UnityEngine;
using UnityEngine.Rendering;

public class MotionBlurVolume : MonoBehaviour
{
    [SerializeField] Volume motionBlurVolume;

    public void ActivateVolume()
    {
        motionBlurVolume.enabled = true;
    }

    public void DeactivateVolume()
    {
        motionBlurVolume.enabled = false;
    }
}
