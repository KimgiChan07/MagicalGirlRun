using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JI_HeartsUI : MonoBehaviour
{
    [Header("��Ʈ UI �̹���")]
    public Image[] hearts;

    [Header("��Ʈ ���º� �̹���")]
    public Sprite fullHeart;  // 2ü���� ��
    public Sprite halfHeart;  // 1ü���� ��
    public Sprite emptyHeart; // 0ü���� ��

    private JI_PlayerStats playerStats;

    private void Awake()
    {
        playerStats = FindObjectOfType<JI_PlayerStats>();
        if(playerStats == null)
        {
            Debug.LogError("�÷��̾� ������ �����ϴ�.");
            return;
        }
    }

    private void Start()
    {
        UpdateHearts(); // �ʱ�ȭ �� ��Ʈ UI ������Ʈ
    }

    public void UpdateHearts() // ��Ʈ UI ������Ʈ
    {
        int curentHp = playerStats.CurrentHp; // ���� ü��
        int maxHp = playerStats.MaxHp;  // �ִ� ü��

        // ��Ʈ ������ �ִ� ü�� / 2�� ���(�� ��Ʈ�� 2ü��)
        // CeilToInt �Լ��� �Ҽ��� �ø� > maxhp = 3 �� �� ������ 2�ϸ� 1.5�� ������ �ø��� �ϸ� 2�� ��
        int heartCount = Mathf.CeilToInt(maxHp / 2f);

        // hearts �迭���� ����� ��Ʈ ������ �Ѱ�, heartCount�� �Ѵ� ��Ʈ�� ��
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < heartCount);
        }

        // i��° ��Ʈ�� 0~1= 1��° ��Ʈ,2~3= 2��° ��Ʈó�� 2ü�� ������ ǥ���ϱ� ������
        // ���� ��Ʈ���� ����� ü��(i*2)�� ���� �� ��Ʈ�� ���� ü���� �����
        for (int i = 0; i < heartCount; i++)
        {
            int heartHp = curentHp - (i * 2); // i��° ��Ʈ�� ü�� ���
            if (heartHp >= 2)
                hearts[i].sprite = fullHeart; // ü�� 2 �̻��̸� hullHeart
            else if (heartHp == 1)
                hearts[i].sprite = halfHeart; // ü�� 1�̸� halfHeart
            else
                hearts[i].sprite = emptyHeart; // ü�� 0�̸� emptyHeart
        }
    }
}
