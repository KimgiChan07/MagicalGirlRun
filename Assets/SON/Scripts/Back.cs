using UnityEngine;

public class BackRemover : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private float destroyThresholdX = -30f;

    public float ScrollSpeed
    {
        get => scrollSpeed;
        set => scrollSpeed = Mathf.Max(0, value);
    }

    void Update()
    {
        // �������� �̵�
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // x ��ǥ�� -30 ���ϰ� �Ǹ� �ı�
        if (transform.position.x <= destroyThresholdX)
        {
            Destroy(gameObject);
        }
    }
}
