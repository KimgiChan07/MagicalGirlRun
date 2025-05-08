using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    // ���� ���������� ����
    public bool[] isStage = new bool[5]; // ���� ��������(1~4) ���п� �迭

    // �������� Ŭ���� �Ÿ�
    public int clearDistance;

    // �������� ����
    public int stageScore = 0;

    // ������ ���������� ����
    public bool isrunnig = false;

    // �÷��̾� ����
    private Player player;

    // ����Ʈ Ŭ���� ���·� Stage Ŭ����� ���� ����
    // ���谡 3�� ���̸� Final Boss Stage �ر�
    public int keyCount = 0;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        StageCheck();
    }

    public void StageClear(int Distance) 
    {
        if (clearDistance <= player.moveDistance)
        {
            // GameManager.Instance.Clear();
        }
    }

    public void StageCheck()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        for (int i = 0; i < isStage.Length; i++)
        {
            isStage[i] = false;
        }

        if (sceneName == "Stage_1")
        {
            isStage[0] = true;
        }
        else if (sceneName == "Stage_2")
        {
            isStage[1] = true;
        }
        else if (sceneName == "Stage_3")
        {
            isStage[2] = true;
        }
        else if (sceneName == "Stage_3")
        {
            isStage[4] = true;
        }
        else
        {
            return;
        }
    }
}
