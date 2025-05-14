using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public Scrollbar scrollBar;
    public ScoreManager scoreManager;

    [Header("���� ��������")]
    [SerializeField] private int isStage = 0;
    [SerializeField] private float beforeSpeed; // ���� �� �ӵ� ����
    private Coroutine speedChange; // ���ӽð� �ڷ�ƾ

    [Header("�⺻ �ӵ��� ������ ����")]
    public static float speed = 5;
    [SerializeField] private float moveDistance;
    [SerializeField] private float destination = 100;

    public static bool hasFinished = false; // Finish �޼��� �ݺ� ���� ����

    // ���� ���� ����
    public static bool[] key = new bool[3];

    private void Start()
    {
        hasFinished = false;
        Time.timeScale = 1f;
        moveDistance = 0;
    }

    private void Update()
    {
        if (hasFinished) return;

        moveDistance += speed * Time.deltaTime;

        if (moveDistance >= destination)
        {
            hasFinished = true;
            scoreManager.SetScore();
            Finish();
        }

        scrollBar.value = Mathf.Clamp01(moveDistance / destination);
    }

    public void ChangeSpeed(float amount, float duration) // 1) ���� �ð����� �ӵ� ����
    {
        beforeSpeed = speed;
        speed += amount;
        Debug.Log($"�ӵ� ���� {speed} (���� �ð�: {duration}��)");
        speedChange = StartCoroutine(RevertSpeed(duration));
    }
    private IEnumerator RevertSpeed(float duration) // 2) ���ӽð� ����� ����
    {
        yield return new WaitForSeconds(duration);
        speed = beforeSpeed;
        Debug.Log($"�ӵ� ���� {speed}");
    }

    private void Finish() // ����Ʈ�� Ŭ���� �ߴٸ� Ű ����
    {
        if (QuestManager.isQuestClear == true)
        {
            GameSystem.key[isStage - 1] = true;
            Debug.Log($"{isStage}��° Ű ȹ��");
        }
    }
}
