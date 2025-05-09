using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayRun()
    {
        //animator.Play("Run");
        Debug.Log("�޸��� �ִϸ��̼� ����");
    }

    public void PlayJump()
    {
        //animator.Play("Jump");
        //animator.speed = 2f;
        Debug.Log("���� �ִϸ��̼� ����");
    }

    public void PlaySlide()
    {
        //animator.Play("Slide");
        Debug.Log("�����̵� �ִϸ��̼� ����");
    }
}
