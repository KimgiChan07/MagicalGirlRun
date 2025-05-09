using UnityEngine;

public class JI_PlayerController : MonoBehaviour
{
    [Header("���� ����")]
    [SerializeField] private float jumpForce = 5f;
    [Header("���� Ƚ�� ����")]
    [SerializeField] private int maxJumpCount = 2; // �ִ� ���� Ƚ��
    private int jumpCount = 0;  // ������� ����� ���� Ƚ��
    [Header("���� ���� ����")]
    [SerializeField] private Transform groundCheck; // ���� ���� ��ġ
    [SerializeField] private float groundCheckRadius = 0.1f; // ���� ���� �ݰ�
    [SerializeField] private LayerMask groundLayer; // ���� ���̾�

    private Rigidbody2D rb;
    private bool isJump = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���� �Է� ����
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            isJump = true;
        }

        if (IsGrounded())
        {
            jumpCount = 0;
        }
    }

    void FixedUpdate()
    {
        HandleJump();
    }
    private void HandleJump()
    {
        if (isJump && jumpCount < maxJumpCount)//isJump�� true�϶� ����
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++; // ���� ����� ���� Ƚ�� ����
            isJump = false;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(
            groundCheck.position,   // �˻��� ���� �߽� ��ġ
            groundCheckRadius,      // ���� ������
            groundLayer             // üũ�� ���̾� ����ũ
        ) != null;                 // ��ġ�� �ݶ��̴��� ������ true, ������ false
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
