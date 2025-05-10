using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> items; // ������ ����Ʈ

    public Transform target; // Ÿ�� ����
    public float spawnOffset = 5f; // Ÿ��(�÷��̾�)�� ���� ��ġ�� �Ÿ�
    public int spawnCount = 15;

    [SerializeField] private float coinInterval = 9f; // ���� ����
    [SerializeField] private float spawnTimer = 0f;

    void Update()
    {
        if (target == null) return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= coinInterval) // ���� ó��
        {
            SpawnCoin();
            spawnTimer = 0f;
        }
    }

    private void SpawnCoin() // ���� ����
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = new Vector3
            ((target.position.x + (i * 2)) + spawnOffset, -3.5f, 0f);
            Instantiate(items[0], spawnPosition, Quaternion.identity);
        }
    }
}
