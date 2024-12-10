using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsView : MonoBehaviour
{
    [SerializeField]
    Button BackButton;
    
    private void Awake()
    {
        BackButton.onClick.AddListener(BackOnClick);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BackOnClick()
    {
        SceneManager.LoadScene(Constants.MainMenuScene);
    }

 
}
