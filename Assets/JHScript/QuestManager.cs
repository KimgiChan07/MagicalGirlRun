using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // �������� �� ����Ʈ ����

    public bool[] stageQuest = new bool[3]; // 1~3�������� ����Ʈ �迭
    public bool[] isQuestClear = new bool[3]; // 1~3�������� ����Ʈ Ŭ���� ����

    // ����Ʈ ���ǿ� �����ϴ� �������� ���� ���� ȹ���ϸ� ����Ʈ Ŭ����
    // ( �ʿ��� ���� ���� )

    private int demand; // ����Ʈ �䱸��
    private int reserves; // ������ ������

    public int keyCount; // Ű ������

    // �������� �Ŵ��� ����
    StageManager stageManager;

    void Start()
    {
        stageManager = FindObjectOfType<StageManager>();
    }

    public void GetQuest()
    {
        for (int i = 0; i < stageManager.isStage.Length; i++)
        {
            if (stageManager.isStage[i] == true)
            {
                stageQuest[i] = true;
            }
        }
    }

    private void Quest_1()
    {
        //if ()
        {

        }
    }

    private void Quest_2()
    {
        //if ()
        {

        }
    }

    private void Quest_3()
    {
        //if ()
        {

        }
    }
}
