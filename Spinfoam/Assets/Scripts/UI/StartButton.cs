using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] MainMenu mainMenu;

    private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            button.enabled = false;
            mainMenu.CloseMenu();
        });
    }
}
