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

        // Змінюємо положення прокрутки в залежності від введення миші
        normalizedPosition.y += scrollInput * scrollSpeed;

        // Обмежте прокрутку від 0 до 1
        normalizedPosition.y = Mathf.Clamp01(normalizedPosition.y);

        // Оновлюємо положення прокрутки
        scrollRect.normalizedPosition = normalizedPosition;
    }
}
