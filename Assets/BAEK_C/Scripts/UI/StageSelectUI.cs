using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
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
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField]private TextMeshProUGUI stageInfoText;
    [SerializeField]private Button startButton;

    [Header("����")]
    [SerializeField] private AudioSource audioSource;     // ȿ������
    [SerializeField] private AudioSource bgmSource;        // BGM��

    [SerializeField] private AudioClip stageSelectSound;   // �������� ���� ȿ����
    [SerializeField] private AudioClip startButtonSound;   // ���� ��ư ȿ����

    private string selectedStage = "";
    private int keysCollected = 0;

    void Start()
    {
        infoPanel.SetActive(false);
        if (bgmSource != null && !bgmSource.isPlaying)
        {
            bgmSource.Play();
        }
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
                AnimateButtonPress(stageButtons[index].transform);
                if (stageSelectSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(stageSelectSound);
                }
                selectedStage = stageInfos[index].stageName;
                stageInfoText.text = $"[{stageInfos[index].stageName} ����]\n{stageInfos[index].stageDescription}";
                infoPanel.SetActive(true);

                ShowBestScore(index);
            }));
        }

        startButton.onClick.AddListener(() => {
            AnimateButtonPress(startButton.transform);
            if (startButtonSound != null && audioSource != null)
            {
                StartCoroutine(PlayStartSoundAndLoadScene());
            }
            else
            {
                // ȿ���� ������ �׳� �� �̵�
                StartSelectedStage();
            }
        });
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

    public void AnimateButtonPress(Transform buttonTransform)
    {
        StartCoroutine(ButtonPressRoutine(buttonTransform));
    }

    private IEnumerator ButtonPressRoutine(Transform buttonTransform)
    {
        Vector3 originalPos = buttonTransform.localPosition;
        Vector3 targetPos = originalPos + new Vector3(0, 20f, 0); //���� �ö󰡴�����

        float duration = 0.1f;
        float elapsed = 0f;

        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            buttonTransform.localPosition = Vector3.Lerp(originalPos, targetPos, t);
            yield return null;
        }

        elapsed = 0f;

        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            buttonTransform.localPosition = Vector3.Lerp(targetPos, originalPos, t);
            yield return null;
        }

       
        buttonTransform.localPosition = originalPos;
    }
    private IEnumerator PlayStartSoundAndLoadScene()
    {
        audioSource.PlayOneShot(startButtonSound);

        
        yield return new WaitForSeconds(startButtonSound.length);

        
        StartSelectedStage();
    }

    void ShowBestScore(int stageIndex)
    {
        string key = $"bestScore_{stageIndex + 1}";
        int best = PlayerPrefs.GetInt(key, 0);
        bestScoreText.text = $"�ְ� ����: {best}";
    }
}