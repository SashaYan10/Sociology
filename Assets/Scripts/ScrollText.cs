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

        // Змінюємо положення прокрутки в залежності від введення
        normalizedPosition.y += verticalInput * scrollSpeed * Time.deltaTime;

        // Обмежте прокрутку від 0 до 1
        normalizedPosition.y = Mathf.Clamp01(normalizedPosition.y);

        // Оновлюємо положення прокрутки
        scrollRect.normalizedPosition = normalizedPosition;
    }
}
