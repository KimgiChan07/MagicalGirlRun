using UnityEngine;

public class JI_PlayerController : MonoBehaviour
{
    [Header("���� ����")]
    [SerializeField] private float jumpForce = 5f;

    [Header("���� Ƚ�� ����")]
    [SerializeField] private int maxJumpCount = 2;    // �ִ� ���� Ƚ��
    private int jumpCount = 0;                        // ������� ����� ���� Ƚ��

    [Header("���� ���� ����")]
    [SerializeField] private Transform groundCheck;   // �ٴ� üũ�� EmptyObject
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;   // "Ground" ���̾� ����

    [Header("�����̵� ����")]
    public GameObject slideObject;               // �����̵� ������Ʈ
    private bool isSlide = false;                    // �����̵� ��û �÷���

    private Rigidbody2D rb;
    private bool isJump = false;                     // ���� ��û �÷���

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            isJump = true;
        }

        if (IsGrounded())
        {
            jumpCount = 0;
        }
        HandleSlide();
    }

    void FixedUpdate()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        if (isJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            isJump = false;
        }
    }

    private bool IsGrounded()
    {
        Collider2D hit = Physics2D.OverlapCircle(
            (Vector2)groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
        return hit != null; //hit�� null�� �ƴϸ� ture�� ��ȯ�� �ٴڿ� ������� �׷��� �ʴٸ� null�̸� false�� ���� �� ������  
    }

    private void HandleSlide()
    {
        if (Input.GetKey(KeyCode.A) && IsGrounded() && !isJump)
        {
            slideObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else
        {
            slideObject.transform.rotation = Quaternion.identity;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
