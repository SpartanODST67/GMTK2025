using TMPro;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    public const string HIGH_SCORE_KEY = "High_score";
    
    public static Scorekeeper instance;
    public TextMeshProUGUI scoreText;
    float score = 0;
    public float Score
    {
        get { return score; }
        set
        {
            score += value;
            if (scoreText != null) scoreText.text = $"Score: {score}";
        }
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    public void SaveHighScore()
    {
        float highScore = Mathf.Max(PlayerPrefs.GetFloat(HIGH_SCORE_KEY), Score);
        PlayerPrefs.SetFloat(HIGH_SCORE_KEY, highScore);
    }
}
