using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("���� ��������")]
    [SerializeField] private int isStage = 0;
    [SerializeField] private int score; // ���� ����

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI nowScoreTxt;
    [SerializeField] private TextMeshProUGUI bestScoreTxt;

    void Start()
    {
        score = 0;
    }

    public void AddScore(int amount) // ���� ����
    {
        if (scoreText == null)
        {
            Debug.Log("�ؽ�Ʈ ������Ʈ�� �Ҵ� ���ּ���");
            return;
        }

        score += amount;
        scoreText.text = score.ToString();
    }

    public void SetScore()
    {
        Debug.Log($"SetScore ȣ��� | ���� ����: {score}");

        if (nowScoreTxt != null)
            nowScoreTxt.text = score.ToString();

        string key = $"bestScore_{isStage}";
        int best = PlayerPrefs.GetInt(key, 0);

        Debug.Log($"����� �ְ� ����: {best}");

        if (score > best) // ���� ������ ��
        {
            PlayerPrefs.SetInt(key, score);
            PlayerPrefs.Save(); 
            bestScoreTxt.text = score.ToString();
        }
        else
        {
            bestScoreTxt.text = best.ToString();
        }

        PlayerPrefs.Save();
    }
}
