using UnityEngine;
using UnityEngine.EventSystems;

public class ShowPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject panel; // Посилання на вашу кнопку
    public float smoothTime = 0.3f; // Плавний час

    private float targetAlpha = 0f;
    private float currentVelocity;

    void Start()
    {
        SetButtonAlpha(0f); // Почнемо з того, що кнопка буде прихована
    }

    void Update()
    {
        float newAlpha = Mathf.SmoothDamp(GetButtonAlpha(), targetAlpha, ref currentVelocity, smoothTime);
        SetButtonAlpha(newAlpha);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetAlpha = 1f; // Показати кнопку при наведенні миші
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetAlpha = 0f; // Сховати кнопку при виході миші
    }

    private float GetButtonAlpha()
    {
        return panel.GetComponent<CanvasGroup>().alpha;
    }

    private void SetButtonAlpha(float alpha)
    {
        panel.GetComponent<CanvasGroup>().alpha = alpha;
    }
}
