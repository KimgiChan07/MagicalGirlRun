using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> items; // ������ ����Ʈ

    public Transform target; // Ÿ�� ����
    private float spawnOffset = 15f; // Ÿ��(�÷��̾�)�� ���� ��ġ�� �Ÿ�

    private float spawnInterval = 1f; // ���� ����
    private float spawnTimer = 0f;

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
        Vector3 spawnPosition = new Vector3
        (target.position.x + spawnOffset, -2f, 0f);

        int num = Random.Range(0, 4);
        Instantiate(items[num], spawnPosition, Quaternion.identity);
    }

}
