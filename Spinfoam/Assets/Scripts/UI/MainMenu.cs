using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    [SerializeField] Animator animator;
    [SerializeField] SceneChanger sceneChanger;
    [SerializeField] bool startClosed = true;
    [SerializeField] TextMeshProUGUI highScoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (!startClosed) OpenMenu();
        else animator.Play("Closed Animation");
    }

    public void OpenMenu()
    {
        int highScore = Scorekeeper.instance.GetHighScore();
        highScoreText.text = $"High Score: {highScore}";
        animator.Play("Opening Animation");
    }

    public void CloseMenu()
    {
        sceneChanger.TransitionScene();
    }
}
