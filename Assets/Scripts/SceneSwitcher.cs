using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string nextScene;  // Ім'я наступної сцени
    public string previousScene;  // Ім'я попередньої сцени

    void Update()
    {
        // Перехід на наступну сцену при натисканні стрілки вправо
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchScene(nextScene);
        }

        // Перехід на попередню сцену при натисканні стрілки вліво
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchScene(previousScene);
        }
    }

    void SwitchScene(string sceneName)
    {
        // Перевірка, чи існує сцена з вказаним ім'ям
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            // Зміна сцени
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene with name '" + sceneName + "' does not exist.");
        }
    }
}
