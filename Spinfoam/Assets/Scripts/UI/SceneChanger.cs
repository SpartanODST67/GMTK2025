using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string targetScene;
    [SerializeField] Image image;
    [SerializeField] Animator animator;

    public void TransitionScene()
    {
        image.enabled = true;
        animator.Play("Fade Out");
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
