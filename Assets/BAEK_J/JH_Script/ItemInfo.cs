using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [Header("������ �̵� �ӵ�")]
    public float moveSpeed = 5; 

    private QuestManager questManager; // ����Ʈ �Ŵ��� ����
    private GameSystem gameSystem; // ���� �ý��� ����

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime; // ���� �̵�
        gameSystem = FindObjectOfType<GameSystem>();
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) // �÷��̾�� ���˽�
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.name.Contains("Coin")) // ����
            {
                gameSystem.AddScore(+100);
            }
            else if (gameObject.name.Contains("Booster")) // �ν���
            {
                gameSystem.ChangeSpeed(+1f, 3f);
            }
            else if (gameObject.name.Contains("Slower")) // ���ο�
            {
                gameSystem.ChangeSpeed(-1f, 3f);
            }
            else if (gameObject.name.Contains("Bomb")) // ��ź
            {
                gameSystem.ChangeLife(-1);
            }
            else if (gameObject.name.Contains("Heart")) // ��Ʈ
            {
                gameSystem.ChangeLife(+1);
            }

            else if (gameObject.name.Contains("QuestItem")) // ����Ʈ ������
            {
                questManager.GetQuestItem();
            }

            Destroy(this.gameObject); // ȹ���� ������ �ı�
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Vector3 pos = transform.position;
            pos.y += 0.2f;
            transform.position = pos;
        }
    }
}
