using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    // ���� ���������� ����
    public static bool[] isStage = new bool[4]; // ���� ��������(1~4)

    private void Awake()
    {
        for (int i = 0; i < isStage.Length; i++)
        {
            isStage[i] = false;
        }

        if (SceneManager.GetActiveScene().name == "Jinhwan")
        {
            isStage[1] = true;
            Debug.Log($"���� ���������� 1�Դϴ�");
        }
        else
        {
            Debug.Log("�������� �ʴ� ���������Դϴ�");
        }

    }
    void Start()
    {

    }

    void Update()
    {

    }
}
