using UnityEngine;

public class JI_CharacterCustomizer : MonoBehaviour
{
    [Header("�ʱ� ������ ���� ������")]
    [Tooltip("�� �������� Spawn�� �� �ڵ����� EquipHat ȣ��")]
    [SerializeField] private GameObject HatPrefab;

    [Header("�Ӹ� ����")]
    [SerializeField] private Transform headSocket;

    private GameObject currentHat;

    private void Start()
    {
        // 1) Ŀ���� ������ ���õ� ���� ������ ������ ����
        if (JI_CustomManager.Instance != null && JI_CustomManager.Instance.SelectedHatPrefab != null)
        {
            EquipHat(JI_CustomManager.Instance.SelectedHatPrefab);
            return;
        }
        // 2) ���� ������ ������ �ʱ� ���������� ����
        if (HatPrefab != null)
            EquipHat(HatPrefab);
    }

    /// <summary>
    /// ���� ���� �޼��� (UI�� �ڵ忡�� ȣ���ص� OK)
    /// </summary>
    public void EquipHat(GameObject hatPrefab)
    {
        if (currentHat != null)
            Destroy(currentHat);

        currentHat = Instantiate(hatPrefab, headSocket);
        currentHat.transform.localPosition = Vector3.zero;
        currentHat.transform.localRotation = Quaternion.identity;
    }
}
