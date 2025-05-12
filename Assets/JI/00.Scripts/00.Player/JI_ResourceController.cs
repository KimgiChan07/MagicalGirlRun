using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JI_ResourceController : MonoBehaviour
{
    private JI_PlayerController playerController;
    private JI_PlayerStats playerStats;
    [Header("��ֹ� ������")]
    public float obstacleDamage = 0;
    [Header("���� ���ӽð�(��)")]
    public float invincibilityDuration = 1.0f;
    [Header("�÷��̾� ���� ����")]
    private bool isInvincible = false;
    private Coroutine invincibilityCoroutine;

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
        if (isInvincible) return; // ���� ������ ���� return
        playerController.HandleDamage(invincibilityDuration);  // �÷��̾� ���� �ִϸ��̼� �ż��� ȣ��
        playerStats.TakeDamage(amount);  // �÷��̾� ü�� ����
        StartInvincibility(invincibilityDuration); //������ ���� �� ���� ���� ����
        if (playerStats.CurrentHp <= 0)  // ü���� 0 ������ �� ���
        {
            Death();
        }
    }
    public void StartInvincibility(float duration)
    {
        // ���� �ڷ�ƾ�� ���� ������ ����
        if (invincibilityCoroutine != null)
        {
            StopCoroutine(invincibilityCoroutine); //�ڷ�ƾ ���� > ���� ���� �� �ߺ� ����
        }
        invincibilityCoroutine = StartCoroutine(InvincibilityCoroutine(duration)); //�ڷ�ƾ ����
    }

    private IEnumerator InvincibilityCoroutine(float duration) //���� �ڷ�ƾ
    {
        isInvincible = true; // ���� ����
        yield return new WaitForSeconds(duration); // ������ ��(duration) ��ŭ ��� (���� ���ӽð�)
        isInvincible = false; // ���� ����
        invincibilityCoroutine = null; // �ڷ�ƾ ����
    }
    private void Death()  // �÷��̾� ��� 
    {
        playerController.HandleDeath();  // �÷��̾� ��� ó��
        enabled = false;  // JI_ResourceController ��Ȱ��ȭ
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Obstacle"))  // ��ֹ��� �浹���� ��
        {
            TakeDamage(obstacleDamage);  // ü�� ����
        }
    }
}