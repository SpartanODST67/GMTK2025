using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class NearMissText : MonoBehaviour
{
    public static NearMissText instance;

    [SerializeField] TextMeshProUGUI text;
    private int nearMisses = 0;
    public int NearMisses
    {
        get { return nearMisses; }
        set
        {
            nearMisses += value;
            if (nearMisses > 5)
            {
                nearMisses = 5;
                if (nearMissDecayCoroutine != null) StopCoroutine(nearMissDecayCoroutine);
                nearMissDecayCoroutine = StartCoroutine(NearMissDecay());
            }
            else if (nearMisses < 0) nearMisses = 0;
            if (nearMissDecayCoroutine == null) nearMissDecayCoroutine = StartCoroutine(NearMissDecay());
            DrawNearMisses();
        }
    }
    Coroutine nearMissDecayCoroutine;
    [SerializeField] float timeBetweenDecay = 5f;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);

        DrawNearMisses();
    }

    IEnumerator NearMissDecay()
    {
        while(nearMisses > 0)
        {
            yield return new WaitForSeconds(timeBetweenDecay);
            NearMisses = -1;
        }
        nearMissDecayCoroutine = null;
    }

    private void DrawNearMisses()
    {
        StringBuilder stringBuilder = new StringBuilder();
        for(int i = 0; i < nearMisses; i++)
        {
            stringBuilder.AppendLine("Near Miss");
        }
        text.text = stringBuilder.ToString();
    }

}
