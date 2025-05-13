using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    private QuestManager questManager; // ����Ʈ �Ŵ��� ����
    private GameSystem gameSystem; // ���� �ý��� ����
    private JI_ResourceController player; // ���ҽ� ��Ʈ�ѷ� ����

    void Update()
    {
        transform.position += Vector3.left * GameSystem.speed * Time.deltaTime; // ���� �̵�
        gameSystem = FindObjectOfType<GameSystem>();
        questManager = FindObjectOfType<QuestManager>();
        player = FindObjectOfType<JI_ResourceController>();
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
                gameSystem.ChangeSpeed(+2f, 5f);
            }
            else if (gameObject.name.Contains("Slower")) // ���ο�
            {
                gameSystem.ChangeSpeed(-1.5f, 5f);
            }
            else if (gameObject.name.Contains("Bomb")) // ��ź
            {
                player.TakeDamage(1);
            }
            else if (gameObject.name.Contains("Heart")) // ��Ʈ
            {
                player.Heal(1);
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
        if (collision.CompareTag("ItemObstacle"))
        {
            Vector3 pos = transform.position;
            pos.y += 0.2f;
            transform.position = pos;
        }
    }
}
