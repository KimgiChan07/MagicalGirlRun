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

    [SerializeField] private float spawnInterval = 9f; // ���� ����
    private float spawnTimer = 0f;


    void Start()
    {
        SpawnItem();
    }

    void Update()
    {
        if (target == null) return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval) // ���� ó��
        {
            SpawnItem();
            spawnTimer = 0f;
        }
    }

    private void SpawnItem() // ������ ����
    {

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = new Vector3
            ((target.position.x + (i * 2)) + spawnOffset, -3.5f, 0f);
            Instantiate(items[0], spawnPosition, Quaternion.identity);
        }
    }
}
