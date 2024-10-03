using UnityEngine;

public class RestartManager : MonoBehaviour
{
    // ��������� �� ������, ��� �� ������ �������������
    public GameObject panelToRestart;

    // ��������� ����� ��'���� ����� ������������
    private bool[] initialObjectStates;

    void Start()
    {
        // �������� �������� ����� ��'����
        SaveInitialObjectStates();
    }

    // ����� ��� ���������� ���������� ����� ��'����
    private void SaveInitialObjectStates()
    {
        // ����������� ����� ��� ��������� �����
        initialObjectStates = new bool[panelToRestart.transform.childCount];

        // �������� ����� ������� ��'���� �����
        for (int i = 0; i < panelToRestart.transform.childCount; i++)
        {
            initialObjectStates[i] = panelToRestart.transform.GetChild(i).gameObject.activeSelf;
        }
    }

    // ����� ��� ����������� �����
    public void RestartPanel()
    {
        // �������� ����� ��� �������� ����� �����
        ResetPanel();
    }

    // ����� ��� �������� ����� �����
    private void ResetPanel()
    {
        // ������� �� ��� ������� ��'����� �����
        for (int i = 0; i < panelToRestart.transform.childCount; i++)
        {
            // ��������� ��������� �� ������� ��'���
            GameObject childObject = panelToRestart.transform.GetChild(i).gameObject;

            // ��������� ���� ��'���� � ���� ���������� ����
            childObject.SetActive(initialObjectStates[i]);
        }
    }
}
