using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class StageInfo
{
    public string stageName;
    public string stageDescription;
}
public class StageSelectUI : MonoBehaviour
{

    [Header("�������� ��ư")] [SerializeField] private List<Button> stageButtons;
    [Header("�������� ����(��ư �����͵����ϰ�)")]
    [SerializeField]private List<StageInfo> stageInfos;

    [Header("UI")]
    [SerializeField] private GameObject infoPanel;
    [SerializeField]private TextMeshProUGUI stageInfoText;
    [SerializeField]private Button startButton;

    private string selectedStage = "";
    private int keysCollected = 0;

    void Start()
    {
        infoPanel.SetActive(false);

        //  �޽����ζ� ��Ʈ�վ�� �ѱ۰���

        if (stageButtons.Count != stageInfos.Count)
        {
            Debug.Log("��ư���� ������ ���� �ٸ�");
            return;
        }

        for (int i = 0; i < stageButtons.Count; i++)
        {
            int index = i;
            stageButtons[i].onClick.AddListener((() =>
            {
                selectedStage = stageInfos[index].stageName;
                stageInfoText.text = $"[{stageInfos[index].stageName} ����]\n{stageInfos[index].stageDescription}";
                infoPanel.SetActive(true);
            }));
        }
        
        startButton.onClick.AddListener((() => StartSelectedStage()));
    }

    void StartSelectedStage()
    {
        if (selectedStage == "BossStage" && keysCollected < 3)
        {           
            return;
        }

        if (string.IsNullOrEmpty(selectedStage))
        {
            Debug.Log("no selected stage");
            return;
        }

        // ������ �������� �̸� ����
        StageData.selectedStage = selectedStage;

        // ���� ������ �̵�
        SceneManager.LoadScene(selectedStage);
    }

    public void StageCleared(string stageName)
    {
        // �ܺο��� �������� Ŭ����� ȣ�� 
        keysCollected++;

        if (keysCollected >= 3)
        {
            
        }
    }
    public static class StageData
    {
        public static string selectedStage;
    }
}