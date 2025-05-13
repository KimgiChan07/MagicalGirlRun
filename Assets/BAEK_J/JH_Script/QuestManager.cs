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
    [Header("���� ��������")]
    // �������� ����Ʈ ����
    public static bool isQuestClear;
    public static bool onQuest;

    [Header("�䱸��, ������")]
    [SerializeField] private int demand = 5;
    [SerializeField] private int reserves = 0;

    void Start()
    {
        Debug.Log($"����Ʈ Ȱ��ȭ");
        onQuest = true;
        isQuestClear = false;
    }

    public void GetQuestItem() // ����Ʈ ������ ����
    {
        reserves ++;

        Debug.Log($"����Ʈ ������ ȹ�� �� {reserves}��");

        if (onQuest && demand <= reserves)
        {
            QuestComplete();
        }
    }

    private void QuestComplete() // ����Ʈ �Ϸ�
    {
        Debug.Log($"����Ʈ �Ϸ�");
        isQuestClear = true;
        onQuest = false;
        reserves = 0;
    }
}
