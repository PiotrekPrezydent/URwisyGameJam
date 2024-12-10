using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndGameView : MonoBehaviour
{
    [SerializeField] 
    Button MenuButton;

    [SerializeField] 
    Button ExitButton;

    private void Awake()
    {
        MenuButton.onClick.AddListener(MenuOnClick);
        ExitButton.onClick.AddListener(ExitOnClick);
    }

    void Start()
    {
        
    }

    void MenuOnClick()
    {
        SceneManager.LoadScene(Constants.MainMenuScene);
    }
    
    void ExitOnClick()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    void Update()
    {
        
    }
}
