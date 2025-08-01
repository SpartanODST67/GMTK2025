using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scorekeeper.instance.scoreText = text;
        Scorekeeper.instance.Score = 0;
    }
}
