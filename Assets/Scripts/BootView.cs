using Boot.Systems;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BootView : MonoBehaviour
{
    [SerializeField]
    EventSystem _eventSystem;
    private void Awake()
    {
        DependencyInjectorSystem.BindConfigs();
        InputSystem.Initialize();
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(_eventSystem);

        var load =SceneManager.LoadSceneAsync(Constants.MainMenuScene);




    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
