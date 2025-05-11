using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Build.Content;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // �������� ����Ʈ ����
    public static bool[] isQuestClear = new bool[3];
    public static bool[] onQuest = new bool[3]; 

    // ����Ʈ ������ �䱸��
    private int demand = 5;
    // ������ ������
    private int reserves = 0;

    void Start()
    {
        GetQuest();
    }

    private void GetQuest() // ���������� ���� ����Ʈ ������ �䱸�� ����
    {
        for (int i = 0; i < onQuest.Length; i++)
        {
            if (GameSystem.key[i] == false && StageManager.isStage[i])
            {
                onQuest[0] = true;
                Debug.Log($"{i}��° ����Ʈ Ȱ��ȭ");
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
