using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
    
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

}
