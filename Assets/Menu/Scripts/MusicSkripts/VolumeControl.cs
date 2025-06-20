using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    
    public Slider volumeSlider;
    public MusicController audioManager;

    void Start()
    {
        MusicController musicController = FindObjectOfType<MusicController>();
        if (musicController != null)
        {
            volumeSlider = GetComponent<Slider>();
            if (volumeSlider != null)
            {
                volumeSlider.onValueChanged.AddListener(musicController.SetMusicVolume);
            }
        }

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }
    void SetVolume(float volume)
    {
        audioManager.SetMusicVolume(volume);
    }
}
