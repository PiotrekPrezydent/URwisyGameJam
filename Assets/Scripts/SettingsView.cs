using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class SettingsView : MonoBehaviour
{
    [SerializeField]
    Button BackButton;

    [SerializeField] 
    Slider soundSlider;

    [SerializeField] 
    AudioMixer masterMixer;
    
    
    private void Awake()
    {
        BackButton.onClick.AddListener(BackOnClick);
    }

    void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BackOnClick()
    {
        SceneManager.LoadScene(Constants.MainMenuScene);
    }

    public void SetVolume(float _value)
    {
        if (_value < 1)
        {
            _value = .001f;
        }

        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);
    }
    
    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float _value)
    {
        soundSlider.value = _value;
    }
}
