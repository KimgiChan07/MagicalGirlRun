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
    public int onQuest = 0;
    public static bool[] isQuestClear = new bool[3];

    // ���� �������� ��
    private int stage = StageManager.isStage;
    // ����Ʈ ������ �䱸��
    private int demand = 0;
    // ������ ������
    private int reserves = 0;

    void Start()
    {
    }

    private void Update()
    {

    }
    private void GiveQuest() // ���������� ���� ����Ʈ ������ �䱸�� ����
    {

    }
}
