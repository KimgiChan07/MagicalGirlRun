using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    // ���� ���������� ����
    public static int isStage = 0; // ���� ��������(1~4) ���п� �迭

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

    void Update()
    {

    }

    public void StageClear(int Distance)  // Stage Clear ����
    {
        for (int i = 0; i < isStage.Length; i++)
        {
            if (isStage[i] == true)
            {

            }
        }
    }

    public void StageCheck() // ���� �������� üũ
    {
        string sceneName = SceneManager.GetActiveScene().name;

        for (int i = 0; i < isStage; i++)
        {
            if (sceneName == $"Stage_{i}")
            {
                isStage = i;
                break;
            }
        }
    }
}
