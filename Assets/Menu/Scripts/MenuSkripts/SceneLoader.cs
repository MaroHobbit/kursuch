using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string SampleScene)
    {
        Time.timeScale = 1; // Возобновляем время
        SceneManager.LoadScene(SampleScene);
    }
}

