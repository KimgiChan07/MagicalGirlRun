using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public int life = 3;
    private float beforeSpeed; // ���� �� �ӵ� ����
    private Coroutine speedChange; // ���ӽð� �ڷ�ƾ
    public int stageScore;

    [Header("�ӵ��� ������ ����")]
    [SerializeField] private float speed = 3;
    [SerializeField] private float moveDistance;
    [SerializeField] private float destination = 100;

    bool hasFinished = false;

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
            Finish();
            moveDistance = 0;
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

    public void ChangeLife(int amount) // ü�� ����
    {
        life += amount;
        Debug.Log($"ü�� ���� {life}+{amount}");
    }

    public void AddScore(int amount) // ���� ����
    {
        stageScore += amount;
        //Debug.Log($"ȹ�� ���� {stageScore}");
        //Debug.Log($"�̵� �Ÿ� {moveDistance:N1}m");
    }

    private void Finish() // ����Ʈ�� Ŭ���� �ߴٸ� Ű ����
    {
        for (int i = 0; i <= key.Length; i++)
        {
            if (QuestManager.isQuestClear[i] == true)
            {
                GameSystem.key[i] = true;
                Debug.Log($"{i + 1}��° Ű ȹ��");
            }
        }
    }
}
