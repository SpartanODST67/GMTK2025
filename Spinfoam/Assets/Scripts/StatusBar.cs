using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;

    public void UpdateStatusBar(float maxValue, float currentValue)
    {
        rectTransform.localScale = new Vector3(currentValue / maxValue, rectTransform.localScale.y, rectTransform.localScale.z);
    }
}
