using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ItemSpawner : MonoBehaviour
{
    [Header("Ÿ�� ����")]
    public Transform target; // Ÿ�� ����
    [SerializeField] private float spawnOffset = 15f; // Ÿ��(�÷��̾�)�� ���� ��ġ�� �Ÿ�

    [Header("������ ����Ʈ�� ���� ����")]
    public List<GameObject> items;
    [SerializeField] private float coin_Y = -1.5f;
    [SerializeField] private int spawnCount = 15; // �ѹ��� ��ȯ�ϴ� ������ ��
    [SerializeField] private float spawnInterval = 6; // ������ ���� ����

    private float spawnTimer = 0f; // ���� ���� ������
    private int itemTurn = 1; // ������ ���� �ֱ� ����

    private void Start()
    {
        Spawnitem();
    }

    void Update()
    {


        spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval) // ���� ó��
            {
                Spawnitem();
                spawnTimer = 0f;
            }
    }

    private void Spawnitem() // ������ ����
    {
        if (items == null) return;

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = new Vector3
            ((target.position.x + (i * 2)) + spawnOffset, -2.5f, 0f);

            if (i == spawnCount - 1 && itemTurn == 2) // �� 2��° ���� �ֱ� �������� Ư�� ������ ����
            {
                int random = Random.Range(1, items.Count);
                Instantiate(items[random], spawnPosition, Quaternion.identity);
            }
            else // �� �� ���� ����
            {
                Instantiate(items[0], spawnPosition, Quaternion.identity);
            }
        }

        if (itemTurn != 2) // ���� �ֱ� üũ
        {
            itemTurn = 2;
        }
        else if (itemTurn != 1)
        {
            itemTurn = 1;
        }
    }
}
