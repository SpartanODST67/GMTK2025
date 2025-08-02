using System.Collections;
using TMPro;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    public const string HIGH_SCORE_KEY = "High_score";
    
    public static Scorekeeper instance { get; private set; }
    public TextMeshProUGUI scoreText;
    int score = 0;
    [SerializeField] int scorePerSecond = 10;
    Coroutine scoreTime;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            if (scoreText != null) scoreText.text = $"Score: {score}";
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartScoredTime();
    }

    public void SaveHighScore()
    {
        int highScore = Mathf.Max(PlayerPrefs.GetInt(HIGH_SCORE_KEY), Score);
        PlayerPrefs.GetInt(HIGH_SCORE_KEY, highScore);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE_KEY);
    }

    public void AddScore(int score)
    {
        Score += score;
    }

    public void StartScoredTime()
    {
        scoreTime = StartCoroutine(ScoreTime());
    }

    public void StopScoredTime()
    {
        StopCoroutine(scoreTime);
    }

    IEnumerator ScoreTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            AddScore(scorePerSecond);
        }
    }
}
