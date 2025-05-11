using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeInScene : MonoBehaviour
{
    public Image[] images;               // UI �̹����� (��� �̹��� ��)
    public TextMeshProUGUI[] textUI;     // UI �ؽ�Ʈ�� (���, �̸� ��)
    public GameObject[] panels;          // ���� ��ȭ �гε�
    public float fadeDuration = 2f;      // ��ü ���� ������ ��Ÿ���� �ð�
    public BadEndingManager badEndingManager;
    void Start()
    {
        // ���� �ε�Ǹ� ��� UI ����� ���İ��� 0���� �����Ͽ� �����, ������ ���̰� �Ѵ�.
        StartCoroutine(FadeIn());
    }

    // ���� UI ��Ҹ� ������ ��Ÿ���� �ϴ� �Լ�
    IEnumerator FadeIn()
    {
        // ��� �̹����� �ؽ�Ʈ�� ���İ��� 0���� ���� (����)
        SetUIAlpha(0f);

        // �� �гο� ���� CanvasGroup�� �߰��ϰ� ���İ��� 0���� ����
        foreach (GameObject panel in panels)
        {
            CanvasGroup panelCanvasGroup = panel.GetComponent<CanvasGroup>();
            if (panelCanvasGroup == null)
            {
                panelCanvasGroup = panel.AddComponent<CanvasGroup>();
            }
            panelCanvasGroup.alpha = 0f;
        }

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alphaValue = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);

            // �� UI ����� ���İ��� ������ ������Ŵ
            SetUIAlpha(alphaValue);

            // �� �г��� ���İ��� ������ ������Ŵ
            foreach (GameObject panel in panels)
            {
                CanvasGroup panelCanvasGroup = panel.GetComponent<CanvasGroup>();
                panelCanvasGroup.alpha = alphaValue;
            }

            yield return null;
        }

        // ���������� ���İ��� 1�� ���� (������ ���̰�)
        SetUIAlpha(1f);

        // ��� �г��� ���İ��� 1�� ����
        foreach (GameObject panel in panels)
        {
            CanvasGroup panelCanvasGroup = panel.GetComponent<CanvasGroup>();
            panelCanvasGroup.alpha = 1f;
        }
    }

    // ��� UI ����� ���İ��� �����ϴ� �Լ�
    private void SetUIAlpha(float alpha)
    {
        // �̹����� ���İ� ����
        foreach (Image img in images)
        {
            Color color = img.color;
            color.a = alpha;
            img.color = color;
        }

        // �ؽ�Ʈ�� ���İ� ����
        foreach (TextMeshProUGUI txt in textUI)
        {
            Color color = txt.color;
            color.a = alpha;
            txt.color = color;
        }

    }
}
