using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JI_ResourceController : MonoBehaviour
{
    private JI_PlayerController playerController;
    private JI_PlayerStats playerStats;

    private void Awake()
    {
        playerController = GetComponent<JI_PlayerController>();
        playerStats = GetComponent<JI_PlayerStats>();
    }
    private void Start()
    {

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))  // HŰ�� ������ �� ü�� ȸ��
        {
            TakeDamage(1f);
        }
    }

    public void Heal(float amount)
    {
        playerStats.Heal(amount);  // �÷��̾� ü�� ȸ��
    }

    public void TakeDamage(float amount)
    {
        playerStats.TakeDamage(amount);  // �÷��̾� ü�� ����
        if (playerStats.CurrentHp <= 0)  // ü���� 0 ������ �� ���
        {
            Death();
        }
    }

    private void Death()  // �÷��̾� ��� 
    {
        playerController.HandleDeath();  // �÷��̾� ��� ó��
        enabled = false;  // JI_ResourceController ��Ȱ��ȭ
    }
}