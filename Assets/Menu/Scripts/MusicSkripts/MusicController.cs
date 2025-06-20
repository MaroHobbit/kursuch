using System;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioSource musicSource; // Объявление переменной типа AudioSource
    

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (backgroundMusic != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }
    }

    // Метод для управления громкостью музыки
    public void SetMusicVolume(float volume)
    {
        volume = Mathf.Clamp01(volume); // Убедимся, что уровень громкости в диапазоне от 0 до 1
        musicSource.volume = volume; // Установим уровень громкости музыки
    }

    // Метод для воспроизведения музыки
    public void PlayMusic()
    {
        musicSource.Play(); // Запустим воспроизведение музыки
    }

    // Метод для остановки воспроизведения музыки
    public void StopMusic()
    {
        musicSource.Stop(); // Остановим воспроизведение музыки
    }
}


