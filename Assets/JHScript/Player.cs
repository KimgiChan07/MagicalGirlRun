using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �÷��̾� ����
    Rigidbody2D _rigidbody;

    // �÷��̾� �̵� �Ÿ�
    public float moveDistance;
    private Vector2 startPosition;

    // �÷��̾� �̵� �ӵ�, ���� ����
    public int speed = 3; // �̵� �ӵ�
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
    private void FixedUpdate()
    {

    }
}
