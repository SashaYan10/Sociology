using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TextHighlighter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text textComponent;
    private Vector3 originalScale;
    public float scaleFactor = 1.1f; // ������ ��������� ������
    public float animationDuration = 0.2f; // ��������� �������

    private Coroutine currentAnimation;

    void Start()
    {
        // �������� ��������� Text
        textComponent = GetComponent<Text>();

        // �������� ����������� ����� ������
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // ��������� ��������� ��������, ���� ���� ��� ��������
        if (currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
        }

        // ��������� �������� ��� ������ �������
        currentAnimation = StartCoroutine(SmoothScaleChange(originalScale * scaleFactor));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ��������� ��������� ��������, ���� ���� ��� ��������
        if (currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
        }

        // ��������� �������� ��� ������ ������� � ���������� ������
        currentAnimation = StartCoroutine(SmoothScaleChange(originalScale));
    }

    private IEnumerator SmoothScaleChange(Vector3 targetScale)
    {
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Mathf.Clamp01(elapsedTime / animationDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale; // ����������� ����� �������� � ���� �������
    }
}
