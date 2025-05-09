using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMover : MonoBehaviour
{
    public float moveSpeed = 3f; // ������ �̵� �ӵ�

    private GameSystem gameSystem; // ���� �ý��� ����

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime; // ���� �̵�
        gameSystem = FindObjectOfType<GameSystem>();
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
                gameSystem.ChangeSpeed(+1f);
            }
            else if (gameObject.name.Contains("Slower")) // ���ο�
            {
                gameSystem.ChangeSpeed(-1f);
            }
            else if (gameObject.name.Contains("Bomb")) // ��ź
            {
                gameSystem.ChangeLife(-1);
            }
            else if (gameObject.name.Contains("Heart")) // ��Ʈ
            {
                gameSystem.ChangeLife(+1);
            }
            else if (gameObject.name.Contains("Key_1")) // ����
            {
                gameSystem.AddKey_1();
            }
            else if (gameObject.name.Contains("Key_2")) // ����
            {
                gameSystem.AddKey_2();
            }
            else if (gameObject.name.Contains("Key_3")) // ����
            {
                gameSystem.AddKey_3();
            }

            Destroy(this.gameObject); // ȹ���� ������ �ı�
        }
    }
}
