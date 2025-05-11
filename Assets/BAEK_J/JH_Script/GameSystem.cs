using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public int life = 3;

    private int stageScore = 0;

    [Header("�ӵ��� ������")]
    [SerializeField] private float speed = 3;
    [SerializeField] private float destination = 100;
    private float moveDistance;

    // ���� ���� ����
    public bool key_1 = false;
    public bool key_2 = false;
    public bool key_3 = false;

    void Start()
    {
    }

    void Update()
    {
        moveDistance += speed * Time.deltaTime;

        if (moveDistance >= destination)
        {
            Finish();
            moveDistance = 0;
        }
    }

    public void ChangeSpeed(float amount) // �ӵ� ����
    {
        speed += amount;
        Debug.Log($"�ӵ� {amount}");
    }

    public void ChangeLife(int amount) // ü�� ����
    {
        life += amount;
        Debug.Log($"ü�� {amount}");
    }

    public void AddScore(int amount) // ���� ����
    {
        stageScore += amount;
        Debug.Log($"ȹ�� ���� {stageScore}");
        Debug.Log($"ȹ�� ���� {moveDistance}");
    }

    public void GetKey() // Ű 1~3 ����
    {
        if (StageManager.isStage == 1)
        {
            key_1 = true;
            Debug.Log("key_1 ȹ��");
        }
        else if (StageManager.isStage == 2)
        {
            key_2 = true;
            Debug.Log("key_2 ȹ��");
        }
        else if (StageManager.isStage == 3)
        {
            key_3 = true;
            Debug.Log($"key_3 ȹ��");
        }
    }
    private void Finish() // ����Ʈ�� Ŭ���� �ߴٸ� ���� ��ȯ
    {
        if (QuestManager.isQuestClear[0] == true)
        {
            //SpawnBoss_1();
        }
        else if (QuestManager.isQuestClear[1] == true)
        {
            //SpawnBoss_2();
        }
        else if (QuestManager.isQuestClear[2] == true)
        {
            //SpawnBoss_3();
        }
        else
        {
            StageClear();
        }
    }

    private void StageClear() // ���â 
    {
        Time.timeScale = 0f;
    }
}
