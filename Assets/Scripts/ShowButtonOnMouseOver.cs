using UnityEngine;
using UnityEngine.EventSystems;

public class ShowButtonOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject button; // Посилання на вашу кнопку
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
        return button.GetComponent<CanvasGroup>().alpha;
    }

    private void SetButtonAlpha(float alpha)
    {
        button.GetComponent<CanvasGroup>().alpha = alpha;
    }
}
