using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StageSelectUI : MonoBehaviour
{
    public Button stage1Button;
    public Button stage2Button;
    public Button stage3Button;
    public Button bossStageButton;
    public GameObject infoPanel;
    public TextMeshProUGUI infoText;
    public Button startButton;

    private string selectedStage = "";
    private int keysCollected = 0;

    void Start()
    {
        bossStageButton.gameObject.SetActive(false);
        infoPanel.SetActive(false);

        // ��ư �̺�Ʈ ��� �ؽ�Ʈ �޽����ζ� ��Ʈ�վ�� �ѱ۰���
        stage1Button.onClick.AddListener(() => SelectStage("Stage1", "���̵�: ����\n����:? "));
        stage2Button.onClick.AddListener(() => SelectStage("Stage2", "���̵�: �߰�\n����: ?"));
        stage3Button.onClick.AddListener(() => SelectStage("Stage3", "���̵�: �����\n����:? "));
        bossStageButton.onClick.AddListener(() => SelectStage("BossStage", "���̵�: ???"));

        startButton.onClick.AddListener(() => StartSelectedStage());
    }

    void SelectStage(string stageName, string info)
    {
       
        selectedStage = stageName;
        infoText.text = $"[{stageName} ����]\n{info}";
        infoPanel.SetActive(true);
 

    }

    void StartSelectedStage()
    {
        if (selectedStage == "BossStage" && keysCollected < 3)
        {           
            return;
        }

        // ������ �������� �̸� ����
        StageData.selectedStage = selectedStage;

        // ���� ������ �̵�
        SceneManager.LoadScene("StageScene");
    }

    public void StageCleared(string stageName)
    {
        // �ܺο��� �������� Ŭ����� ȣ�� 
        keysCollected++;
        

        if (keysCollected >= 3)
        {
            bossStageButton.gameObject.SetActive(true);
        }
    }
    public static class StageData
    {
        public static string selectedStage;
    }
}