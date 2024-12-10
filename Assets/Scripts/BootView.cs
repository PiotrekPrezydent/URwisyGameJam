using Boot.Systems;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class BootView : MonoBehaviour
{
    [SerializeField]
    EventSystem _eventSystem;
    
    [SerializeField] 
    AudioMixer masterMixer;
    
    [SerializeField] 
    Slider soundSlider;
    private void Awake()
    {
        DependencyInjectorSystem.BindConfigs();
        InputSystem.Initialize();
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(_eventSystem);
        var load =SceneManager.LoadSceneAsync(Constants.MainMenuScene);
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    public void SetVolume(float _value)
    {
        if (_value < 1)
        {
            _value = .001f;
        }
        
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);
    }
    
    
    

}
