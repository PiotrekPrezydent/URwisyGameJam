using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField]
    Button StartButton;

    [SerializeField]
    Button ExitButton;
    private void Awake()
    {
        StartButton.onClick.AddListener(StartOnClick);
        ExitButton.onClick.AddListener(ExitOnClick);
    }


    void StartOnClick()
    {
        SceneManager.LoadScene(Constants.GameScene);
    }

    void ExitOnClick()
    {

    }


}
