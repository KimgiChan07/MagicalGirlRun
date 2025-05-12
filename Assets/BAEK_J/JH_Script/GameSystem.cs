using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameSystem : MonoBehaviour
{
   [SerializeField] private int stageScore; // ���� ����
   [SerializeField] private float beforeSpeed; // ���� �� �ӵ� ����
    private Coroutine speedChange; // ���ӽð� �ڷ�ƾ

    [Header("�ӵ��� ������ ����")]
    [SerializeField] public static float speed = 5;
    [SerializeField] private float moveDistance;
    [SerializeField] private float destination = 100;

    private bool hasFinished = false; // Finish �޼��� �ݺ� ���� ����

    // ���� ���� ����
    public static bool[] key = new bool[3];

    void Update()
    {
        if (hasFinished) return;

        moveDistance += speed * Time.deltaTime;

        if (moveDistance >= destination)
        {
            hasFinished = true;
            Time.timeScale = 0f;
            moveDistance = 0;
            stageScore = 0;
            Finish();
        }
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

    public void AddScore(int amount) // ���� ����
    {
        stageScore += amount;
    }

    private void Finish() // ����Ʈ�� Ŭ���� �ߴٸ� Ű ����
    {
        for (int i = 0; i < key.Length; i++)
        {
            if (QuestManager.isQuestClear[i] == true)
            {
                GameSystem.key[i] = true;
                Debug.Log($"{i + 1}��° Ű ȹ��");
            }
        }
    }
}
