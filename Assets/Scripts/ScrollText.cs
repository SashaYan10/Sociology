using UnityEngine;
using UnityEngine.UI;

public class ScrollText : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float scrollSpeed = 1.0f;

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 normalizedPosition = scrollRect.normalizedPosition;

        // ������� ��������� ��������� � ��������� �� ��������
        normalizedPosition.y += verticalInput * scrollSpeed * Time.deltaTime;

        // ������� ��������� �� 0 �� 1
        normalizedPosition.y = Mathf.Clamp01(normalizedPosition.y);

        // ��������� ��������� ���������
        scrollRect.normalizedPosition = normalizedPosition;
    }
}
