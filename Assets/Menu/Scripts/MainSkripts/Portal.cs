using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject sceneController; // Ссылка на объект SceneController
    public float rotationSpeed = 50f; // Скорость вращения объекта

    void Update()
    {
        transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hero")
        {
            if (sceneController != null)
            {
                sceneController.SetActive(true);
            }
        }
    }
}
