using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeCam : MonoBehaviour
{
    [SerializeField] private Image img;       // Image màu đen full màn hình
    [SerializeField] private float speed = 1f; // Tốc độ fade

    private Coroutine currentRoutine;

    private void Start()
    {
        // Khởi động với alpha = 1 (đen toàn màn) => fade in
        SetAlpha(1f);
        FadeIn(() =>
        {
            img.gameObject.SetActive(false);
        });
    }

    public void FadeIn(System.Action onComplete = null)
    {
        if (currentRoutine != null) StopCoroutine(currentRoutine);
        currentRoutine = StartCoroutine(FadeTo(0f, onComplete)); // fade về trong suốt
    }

    public void FadeOut(System.Action onComplete = null)
    {
        if (currentRoutine != null) StopCoroutine(currentRoutine);
        currentRoutine = StartCoroutine(FadeTo(1f, onComplete)); // fade ra đen
    }

    private IEnumerator FadeTo(float targetAlpha, System.Action onComplete)
    {
        float startAlpha = img.color.a;
        float t = 0f;
        img.gameObject.SetActive(true);
        while (Mathf.Abs(img.color.a - targetAlpha) > 0.01f)
        {
            t += Time.deltaTime * speed;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            SetAlpha(newAlpha);
            yield return null;
        }

        SetAlpha(targetAlpha);
        onComplete?.Invoke();
    }

    private void SetAlpha(float alpha)
    {
        Color color = img.color;
        color.a = alpha;
        img.color = color;
    }
}
