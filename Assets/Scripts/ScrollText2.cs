using UnityEngine;
using UnityEngine.UI;

public class ScrollText2 : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float scrollSpeed = 1.0f;

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        Vector2 normalizedPosition = scrollRect.normalizedPosition;

        // ������� ��������� ��������� � ��������� �� �������� ����
        normalizedPosition.y += scrollInput * scrollSpeed;

        // ������� ��������� �� 0 �� 1
        normalizedPosition.y = Mathf.Clamp01(normalizedPosition.y);

        // ��������� ��������� ���������
        scrollRect.normalizedPosition = normalizedPosition;
    }
}
