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
    bool isJump = false;

    // ���� ���� ����
    public bool key_1 = false;
    public bool key_2 = false;
    public bool key_3 = false;

    public float speed = 3; // �̵� �ӵ�
    public float jumpForce = 10; // ���� ����

    void Start()
    {
        startPosition = transform.position; // �̵� ���� ��ġ ���
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveDistance = Vector2.Distance(startPosition, transform.position); // �̵� �Ÿ� ����

        if (Input.GetMouseButtonDown(0))
        {
            isJump = true;
        }
    }
    private void FixedUpdate()
    {

        Vector3 velocity = _rigidbody.velocity;

        if (isJump)
        {
            velocity.y += jumpForce;
            isJump = false;
        }
        _rigidbody.velocity = velocity;
    }
}
