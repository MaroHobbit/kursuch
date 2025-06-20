using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // ћетод дл€ закрыти€ приложени€
    public void QuitGame()
    {
        // «авершаем приложение (работает в build)
        // Application.Quit();

        // Ётот код не будет выполнен в редакторе Unity
        // ƒл€ тестировани€ в редакторе можно использовать #if UNITY_EDITOR
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
