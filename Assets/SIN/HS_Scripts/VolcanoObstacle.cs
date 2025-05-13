using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class VolcanoObstacle : ObstacleController
{
    public float eruptionDelay = 3f; // �� �� �ڿ� ��������
    private Animator animator;
    private bool hasErupted = false;
    private float timer = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (hasErupted) return;

        timer += Time.deltaTime;

        if (timer >= eruptionDelay)
        {
            TriggerEruption();
        }
    }

    void TriggerEruption()
    {
        animator.SetTrigger("Explode");
        hasErupted = true;
    }

    protected override void OnPlayerHit()
    {
        // �÷��̾ ȭ��� �浹���� ���� ����
        Debug.Log("�÷��̾ ȭ�꿡 ��ҽ��ϴ�!");
    }
}