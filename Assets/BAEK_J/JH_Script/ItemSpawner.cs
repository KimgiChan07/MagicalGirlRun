using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> items; // ������ ����Ʈ

    public Transform target; // Ÿ�� ����
    public float spawnOffset = 15f; // Ÿ��(�÷��̾�)�� ���� ��ġ�� �Ÿ�

    [SerializeField] private float coinInterval = 6f; // ���� ���� ����
    private float coinTimer = 0f; // ���� ���� ������
    public int coinCount = 15; // �ѹ��� ��ȯ�ϴ� ���� ��

    [SerializeField] private float itemInterval = 30f; // ������ ���� ����
    private float itemTimer = 0f; // ���� ���� ������

    private void Start()
    {
        SpawnCoin();
    }
    void Update()
    {
        if (target == null) return;

        coinTimer += Time.deltaTime;
        itemTimer += Time.deltaTime;

        if (target != null)
        {
            if (coinTimer >= coinInterval) // ���� ó��
            {
                SpawnCoin();
                coinTimer = 0f;
            }

            if (itemTimer >= itemInterval)
            {
                SpawnItem();
                itemTimer = 0f;
            }
        }
    }
    private void SpawnCoin() // ���� ����
    {
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 spawnPosition = new Vector3
            ((target.position.x + (i * 2)) + spawnOffset, -2.5f, 0f);
            Instantiate(items[0], spawnPosition, Quaternion.identity);
        }
    }
    private void SpawnItem() // ������ ����
    {
        Vector3 spawnPosition = new Vector3
            ((target.position.x ) + spawnOffset, -1f, 0f);

        int ran = Random.Range(1, items.Count);
        Instantiate(items[ran], spawnPosition, Quaternion.identity);
    }

}
