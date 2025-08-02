using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public static Starter instance;
    public bool gameStarted = false;
    [SerializeField] Animator animator;

    private void Awake()
    {
        instance = this;
    }

    public void KickStart()
    {
        animator.Play("Fade In");
    }

    public void StartGame()
    {
        gameStarted = true;
    }
}
