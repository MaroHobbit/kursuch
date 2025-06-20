using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // ����� ��� �������� ����������
    public void QuitGame()
    {
        // ��������� ���������� (�������� � build)
        // Application.Quit();

        // ���� ��� �� ����� �������� � ��������� Unity
        // ��� ������������ � ��������� ����� ������������ #if UNITY_EDITOR
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
