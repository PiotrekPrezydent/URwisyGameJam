using Boot.Systems;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class BootView : MonoBehaviour
{
    [SerializeField]
    EventSystem _eventSystem;
    
    [SerializeField] 
    AudioMixer masterMixer;
    
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

}
