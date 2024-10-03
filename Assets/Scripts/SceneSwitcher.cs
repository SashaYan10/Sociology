using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string nextScene;  // ��'� �������� �����
    public string previousScene;  // ��'� ���������� �����

    void Update()
    {
        // ������� �� �������� ����� ��� ��������� ������ ������
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchScene(nextScene);
        }

        // ������� �� ��������� ����� ��� ��������� ������ ����
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchScene(previousScene);
        }
    }

    void SwitchScene(string sceneName)
    {
        // ��������, �� ���� ����� � �������� ��'��
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            // ���� �����
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene with name '" + sceneName + "' does not exist.");
        }
    }
}
