using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class TestController10 : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Text questionText;
    public Toggle[] answerToggles; // ������ ������ ������������� Toggle.
    public Text scoreText;
    public GameObject questionPanel; // ������ � ���������
    public GameObject resultPanel;   // ������ ����������

    private int currentQuestion = 0;
    private int score = 0;

    private string[] questions = { "�� � ������������� ������ � �������� ���������?", "�� ���������� �� �������� ���������:" };
    private string[][] answers = {
        new string[] { "����� ����������� �����������", "����� �������� �������� �������� ��� � ����", "����� ����������� �����������", "����� �������� �������� ������ ��� � ��������", "����� �������� �� ������������� ��������������", "����� ������ �� �������� ��������������" },
        new string[] { "���� � �����", "��������� � �������", "������� � �������", "����������� � �����������", "��������, ��������, ��������", "������� � �����" }
    };

    // ������ ������ ���������� �������� ��� ������� �������.
    private List<List<int>> correctAnswersList = new List<List<int>> {
        new List<int> { 1, 2, 5 },
       new List<int> { 0, 1, 2, 3, 4, 5 }
    };

    private void Start()
    {
        ShowQuestion();
        if (scoreManager != null)
        {
            // ��������� ��� ��� ��������� ����.
            scoreManager.AddScore(score);
        }
        else
        {
            Debug.LogError("scoreManager is not initialized!"); // ������� ����������� ��� �������, ���� scoreManager �� ������������.
        }
    }

    private void ShowQuestion()
    {
        questionText.text = questions[currentQuestion];

        for (int i = 0; i < answerToggles.Length; i++)
        {
            answerToggles[i].isOn = false; // ������������ ��������� ��� �����������.
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

        // ��������, �� ����� ������� � �����������.
        if (IsListEqual(selectedAnswers, correctAnswersList[currentQuestion]))
        {
            score++; // �������� ����, ���� ������� ���������.
        }

        if (currentQuestion < questions.Length - 1)
        {
            currentQuestion++;
            ShowQuestion();
        }
        else
        {
            scoreText.text = "����: " + score.ToString();

            // ������ ���� �� ScoreManager.
            scoreManager.AddScore(score);

            // ��������� ������ ������ � �������� ������ ����������.
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

