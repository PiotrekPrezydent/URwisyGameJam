using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField]
    Button StartButton;

    [SerializeField]
    Button ExitButton;

    [SerializeField] 
    Button SettingsButton;
    private void Awake()
    {
        StartButton.onClick.AddListener(StartOnClick);
        ExitButton.onClick.AddListener(ExitOnClick);
        SettingsButton.onClick.AddListener(SettingOnClick);
    }


    void StartOnClick()
    {
        SceneManager.LoadScene(Constants.GameScene);
    }

    void SettingOnClick()
    {
        SceneManager.LoadScene(Constants.SettingsMenu);
    }
    void ExitOnClick()
    {
        Debug.Log("quit");
        Application.Quit();
    }


}
