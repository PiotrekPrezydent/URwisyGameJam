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
    AudioMixer myMixer;
    
    [SerializeField] 
    Slider volumeSlider;
    
    
    
    
    private void Awake()
    {
        BackButton.onClick.AddListener(BackOnClick);
    }

    void Start()
    {
        SetVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BackOnClick()
    {
        SceneManager.LoadScene(Constants.MainMenuScene);
    }

    public void SetVolume()
    {
        float volume = volumeSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume)*20);
        Debug.Log(volume);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");

         SetVolume();
    }
}
