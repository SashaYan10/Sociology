using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class TestController7 : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Text questionText;
    public Toggle[] answerToggles; // Замість кнопок використовуємо Toggle.
    public Text scoreText;
    public GameObject questionPanel; // Панель з питаннями
    public GameObject resultPanel;   // Панель результатів

    private int currentQuestion = 0;
    private int score = 0;

    private string[] questions = { "Які з перерахованих стадій «дороги до Бога» належать Серену К'єркегору?" };
    private string[][] answers = {
        new string[] { "історична", "релігійна", "етична", "естетична" }
    };

    // Список списків правильних відповідей для кожного питання.
    private List<List<int>> correctAnswersList = new List<List<int>> {
        new List<int> { 1, 2, 3 }
    };

    private void Start()
    {
        ShowQuestion();
        if (scoreManager != null)
        {
            // Оновлений код для додавання балів.
            scoreManager.AddScore(score);
        }
        else
        {
            Debug.LogError("scoreManager is not initialized!"); // Додайте повідомлення про помилку, якщо scoreManager не ініціалізовано.
        }
    }

    private void ShowQuestion()
    {
        questionText.text = questions[currentQuestion];

        for (int i = 0; i < answerToggles.Length; i++)
        {
            answerToggles[i].isOn = false; // Забезпечення вимкнення усіх перемикачів.
            answerToggles[i].transform.GetChild(1).GetComponent<Text>().text = answers[currentQuestion][i];
        }
    }

    public void CheckAnswer()
    {
        List<int> selectedAnswers = new List<int>();

        for (int i = 0; i < answerToggles.Length; i++)
        {
            if (answerToggles[i].isOn)
            {
                selectedAnswers.Add(i);
            }
        }

        // Перевірка, чи обрані варіанти є правильними.
        if (IsListEqual(selectedAnswers, correctAnswersList[currentQuestion]))
        {
            score++; // Збільшити бали, якщо відповідь правильна.
        }

        if (currentQuestion < questions.Length - 1)
        {
            currentQuestion++;
            ShowQuestion();
        }
        else
        {
            scoreText.text = "Бали: " + score.ToString();

            // Додати бали до ScoreManager.
            scoreManager.AddScore(score);

            // Приховати панель питань і показати панель результатів.
            questionPanel.SetActive(false);
            resultPanel.SetActive(true);
        }
    }
    private bool IsListEqual(List<int> list1, List<int> list2)
    {
        if (list1.Count != list2.Count)
        {
            return false;
        }

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
            {
                return false;
            }
        }

        return true;
    }
}

