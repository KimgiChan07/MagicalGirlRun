using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject backPrefab;     // ������ ��� ������
    [SerializeField] private float spawnInterval = 3f;  // ���� �ֱ�
    [SerializeField] private Vector3 spawnPosition = new Vector3(30f, 0f, 0f); // ���� ��ġ
    [SerializeField] private float scrollSpeed = 2f;    // ��ũ�� �ӵ� (������ ��ü���� ����)

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnGround();
            timer = 0f;
        }
    }

    void SpawnGround()
    {
        GameObject newBack = Instantiate(backPrefab, spawnPosition, Quaternion.identity);

        // ��ũ�� �ӵ� ����
        var remover = newBack.GetComponent<GroundRemover>();
        if (remover != null)
        {
            remover.ScrollSpeed = scrollSpeed;
        }
    }
}