using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField]private AudioMixerGroup _mixer;
    [SerializeField]private Slider _masterSlider;
    [SerializeField]private Slider _musicSlider;

    [SerializeField]private Slider _effectsSlider;
    void Awake()
    {
        loadOptions();      
    }

    private void Update() 
    {
        MasterVolumeChange();
        MusicVolumeChange();
        EffectsVolumeChange();
    }

    public void SoundTogle(bool enable)
    {
        if(enable) _mixer.audioMixer.SetFloat("MasterVolume",0);
        else  _mixer.audioMixer.SetFloat("MasterVolume",-80);
       
    }

    public void ScreenTogle(bool enable){
        Screen.fullScreen = enable;
    }


    public void MasterVolumeChange()
    {
        _mixer.audioMixer.SetFloat("MasterVolume",  _masterSlider.value);
    }

    public void MusicVolumeChange()
    {
        _mixer.audioMixer.SetFloat("MusicVolume",  _musicSlider.value);
    }


    public void EffectsVolumeChange()
    {
        _mixer.audioMixer.SetFloat("EffectsVolume",  _effectsSlider.value);
    }

    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("MasterValue",_masterSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);
        PlayerPrefs.SetFloat("EffectsVolume", _effectsSlider.value);

        loadOptions();

    }

    private void loadOptions(){
        if(PlayerPrefs.HasKey("MasterValue"))
        {
            _masterSlider.value = PlayerPrefs.GetFloat("MasterValue");
            _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            _effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume");
            
        }
        else
        {
            PlayerPrefs.SetFloat("MasterValue",0);
            PlayerPrefs.SetFloat("MusicVolume", 0);
            PlayerPrefs.SetFloat("EffectsVolume", 0);
        }

    }
}
