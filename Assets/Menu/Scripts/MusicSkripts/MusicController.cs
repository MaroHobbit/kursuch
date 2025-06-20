using System;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioSource musicSource; // ���������� ���������� ���� AudioSource
    

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

    // ����� ��� ���������� ���������� ������
    public void SetMusicVolume(float volume)
    {
        volume = Mathf.Clamp01(volume); // ��������, ��� ������� ��������� � ��������� �� 0 �� 1
        musicSource.volume = volume; // ��������� ������� ��������� ������
    }

    // ����� ��� ��������������� ������
    public void PlayMusic()
    {
        musicSource.Play(); // �������� ��������������� ������
    }

    // ����� ��� ��������� ��������������� ������
    public void StopMusic()
    {
        musicSource.Stop(); // ��������� ��������������� ������
    }
}


