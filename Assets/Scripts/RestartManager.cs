using UnityEngine;

public class RestartManager : MonoBehaviour
{
    // Посилання на панель, яку ви хочете перезапустити
    public GameObject panelToRestart;

    // Зберігайте стани об'єктів перед перезапуском
    private bool[] initialObjectStates;

    void Start()
    {
        // Збережіть початкові стани об'єктів
        SaveInitialObjectStates();
    }

    // Метод для збереження початкових станів об'єктів
    private void SaveInitialObjectStates()
    {
        // Ініціалізуйте масив для зберігання станів
        initialObjectStates = new bool[panelToRestart.transform.childCount];

        // Збережіть стани дочірніх об'єктів панелі
        for (int i = 0; i < panelToRestart.transform.childCount; i++)
        {
            initialObjectStates[i] = panelToRestart.transform.GetChild(i).gameObject.activeSelf;
        }
    }

    // Метод для перезапуску панелі
    public void RestartPanel()
    {
        // Викличте метод для скидання стану панелі
        ResetPanel();
    }

    // Метод для скидання стану панелі
    private void ResetPanel()
    {
        // Пройдіть по всіх дочірніх об'єктах панелі
        for (int i = 0; i < panelToRestart.transform.childCount; i++)
        {
            // Отримайте посилання на дочірній об'єкт
            GameObject childObject = panelToRestart.transform.GetChild(i).gameObject;

            // Встановіть стан об'єкта в його початковий стан
            childObject.SetActive(initialObjectStates[i]);
        }
    }
}
