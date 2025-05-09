using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Build.Content;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // �������� ����Ʈ Ŭ���� ����
    public static bool[] isQuestClear = new bool[3];
    // ���� �������� ��
    private int stage = StageManager.isStage;
    // ����Ʈ ������ �䱸��
    private int demand = 0;
    // ������ ������
    private int reserves = 0;

    void Start()
    {
        GiveQuest();
    }

    private void Update()
    {

    }

    private void GiveQuest() // ���������� ���� ����Ʈ ������ �䱸�� ����
    {
        demand = 0;
        reserves = 0;

        if (stage == 1)
        {
            Quest_1();
        }
        else if (stage == 2)
        {
            Quest_2();
        }
        else if (stage == 3)
        {
            Quest_3();
        }
        else
        {
            Debug.Log("�������� �ʴ� �������� �Դϴ�.");
        }
    }

    private void Quest_1()
    {
        demand = 10;
    }
    private void Quest_2()
    {
        demand = 15;
    }
    private void Quest_3()
    {
        demand = 20;
    }

    private void QuestClear() // ����Ʈ Ŭ���� ���� Ȱ��ȭ
    {
        if (stage == 1)
        {
            isQuestClear[0] = true;
        }
        else if (stage == 2)
        {
            isQuestClear[1] = true;
        }
        else if (stage == 3)
        {
            isQuestClear[2] = true;
        }
        else
        {
            return;
        }
    }
}
