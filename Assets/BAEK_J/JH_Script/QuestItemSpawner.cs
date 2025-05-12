using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemSpawner : MonoBehaviour
{
    [Header("Ÿ�� ����")]
    public Transform target; // Ÿ�� ����
    [SerializeField] private float spawnOffset = 15f; // Ÿ��(�÷��̾�)�� ���� ��ġ�� �Ÿ�

    [Header("����Ʈ ������ ����Ʈ�� ���� ����")]
    public List<GameObject> questItems;
    [SerializeField] private float spawn_Y = -1f;
    [SerializeField] private float spawnInterval = 10f; // ������ ���� ����

    private float spawnTimer = 0f; // ���� ���� ������

    void Update()
    {
        if (target == null) return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval) // ���� ó��
        {
            SpawnQuestItem();
            spawnTimer = 0f;
        }
    }

    private void SpawnQuestItem() // ����Ʈ�� �ش��ϴ� ������ ����
    {
        if (questItems == null) return;

        for (int i = 0;  i < QuestManager.onQuest.Length; i++)
        {
            if (QuestManager.onQuest[i])
            {
                Vector3 spawnPosition = new Vector3
                ((target.position.x) + spawnOffset, spawn_Y, 0f);
                Instantiate(questItems[i], spawnPosition, Quaternion.identity);
            }
        }
    }
}
