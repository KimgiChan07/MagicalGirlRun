using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    // ���� ���������� ����
    public static int isStage = 0; // ���� ��������(1~4)
    // �÷��̾� ����
    private JHPlayer player;

    // ����Ʈ Ŭ���� ���·� Stage Ŭ����� ���� ����

    private void Start()
    {
        player = FindObjectOfType<JHPlayer>();
    }

    void Update()
    {

    }
}
