using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("���� ��������")]
    [SerializeField] private int isStage = 0;
    [SerializeField] private int score; // ���� ����

    public Text ScoreTxt;
    public Text nowScoreTxt;
    public Text bestScoreTxt;

    void Start()
    {
        score = 0;
    }

    public void AddScore(int amount) // ���� ����
    {
        score += amount;
    }

    public void SetScore()
    {
        if (nowScoreTxt != null)
            nowScoreTxt.text = score.ToString();

        string key = $"bestScore_{isStage}";

        // ���� ���� ��������
        int best = PlayerPrefs.GetInt(key, 0);

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
