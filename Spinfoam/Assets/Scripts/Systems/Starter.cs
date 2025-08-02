using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public static Starter instance;
    public bool gameStarted = false;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        gameStarted = true;
    }
}
