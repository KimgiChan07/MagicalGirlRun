using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class JHPlayer : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    // �÷��̾� �̵� �Ÿ�
    public float moveDistance;
    // �޸��� ���� ��ġ
    public Vector2 startPosition;

    // �÷��̾� ü��
    public int life = 3;
    // ���� ���� ����
    public bool key_1 = false;
    public bool key_2 = false;
    public bool key_3 = false;

    public float speed = 3; // �̵� �ӵ�
    public float jumpForce = 5; // ���� ����

    void Start()
    {
        startPosition = transform.position; // �̵� ���� ��ġ ���
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveDistance = Vector2.Distance(startPosition, transform.position); // �̵� �Ÿ� ����
    }
}
