using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] MainMenu mainMenu;
    [SerializeField] AudioSource buttonAudio;
    [SerializeField] AudioSource announcer;

    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            button.enabled = false;
            mainMenu.CloseMenu();
            if(announcer != null) announcer.Play();
            else buttonAudio.Play();
        });
    }
}
