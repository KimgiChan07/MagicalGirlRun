using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    // ���� ���������� ����
    public static int isStage = 0; // ���� ��������(1~4)

    // �������� ����
    public static int stageScore = 0;
    // ������������ �Ÿ�
    private float destination = 0; 
    // �÷��̾� ����
    private JHPlayer player;

    // ����Ʈ Ŭ���� ���·� Stage Ŭ����� ���� ����

    private void Start()
    {
        Time.timeScale = 1f;
        player = FindObjectOfType<JHPlayer>();
        DestinationSetting();
    }

    void Update()
    {
        if (player.moveDistance >= destination) // ���������� ����
        {
            Finish();
        }
    }

    private void Finish() // ����Ʈ�� Ŭ���� �ߴٸ� ���� ��ȯ
    {
        if (QuestManager.isQuestClear[0] == true)
        {
            //SpawnBoss_1();
        }
        else if (QuestManager.isQuestClear[1] == true)
        {
            //SpawnBoss_2();
        }
        else if (QuestManager.isQuestClear[2] == true)
        {
            //SpawnBoss_3();
        }
        else
        {
            StageClear();
        }
    }

    private void StageClear() // ���â 
    {
        Time.timeScale = 0f;
    }

    private void DestinationSetting() // ������ �Ÿ� ����
    {
        if (isStage == 1)
        {
            destination = 5000;
        }
        else if (isStage == 2)
        {
            destination = 6000;
        }
        else if (isStage == 3)
        {
            destination = 7000;
        }
        else
        {
            Debug.Log("�������� �ʴ� �������� �Դϴ�.");
            return;
        }
    }
}
