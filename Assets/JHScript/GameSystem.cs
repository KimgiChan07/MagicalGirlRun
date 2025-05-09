using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public Player player;

    public void ChangeSpeed(float amount) // �ӵ� ����
    {
        player.speed += amount;
        Debug.Log($"�ӵ� {amount}");
    }

    public void ChangeLife(int amount) // ü�� ����
    {
        player.life += amount;
        Debug.Log($"ü�� {amount}");
    }

    public void AddScore(int amount) // ���� ����
    {
        StageManager.stageScore += amount;
        Debug.Log($"ȹ�� ���� {StageManager.stageScore}");
    }

    public void AddKey_1() // Ű 1~3 ����
    {
        player.key_1 = true;
        Debug.Log($"key_1 ȹ��");
    }
    public void AddKey_2()
    {
        player.key_2 = true;
        Debug.Log($"key_2 ȹ��");
    }
    public void AddKey_3()
    {
        player.key_3 = true;
        Debug.Log($"key_3 ȹ��");
    }
}
