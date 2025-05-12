using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Build.Content;
using UnityEditor.SceneManagement;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int isStage = 0; // ���� ��������(1~4)

    // �������� ����Ʈ ����
    public static bool[] isQuestClear = new bool[3];
    public static bool[] onQuest = new bool[3];

    // ����Ʈ ������ �䱸��
    [SerializeField] private int demand = 5;
    // ������ ������
    [SerializeField] private int reserves = 0;

    void Start()
    {
        GetQuest();
    }

    private void GetQuest() // ���������� ���� ����Ʈ ������ �䱸�� ����
    {
        for (int i = 0; i < onQuest.Length; i++)
        {
            if (!GameSystem.key[i] && isStage == i + 1)
            {
                onQuest[i] = true;
                Debug.Log($"{i + 1}�������� ����Ʈ Ȱ��ȭ");
            }
        }
    }

    public void GetQuestItem() // ����Ʈ ������ ����
    {
        reserves ++;

        Debug.Log($"����Ʈ ������ ȹ�� �� {reserves}��");

        for (int i = 0; i < onQuest.Length; i++)
        {
            if (onQuest[i] && demand <= reserves)
            {
                QuestComplete(i);
            }
        }
    }

    private void QuestComplete(int num) // ����Ʈ �Ϸ�
    {
        Debug.Log($"����Ʈ �Ϸ�");
        isQuestClear[num] = true;
        onQuest[num] = false;
        reserves = 0;
    }
}
