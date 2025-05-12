using UnityEngine;

/// <summary>
/// CustomManager�� Ŀ���� ���� ���� �÷��� �� ����
/// ĳ���� Ŀ���� ���� ������ �����մϴ�.
/// </summary>
public class JI_CustomManager : MonoBehaviour
{
    public static JI_CustomManager Instance { get; private set; }

    /// <summary>
    /// �÷��̾ ������ ���� ������
    /// </summary>
    public GameObject SelectedHatPrefab { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    /// <summary>
    /// ���� ���� ������ �����մϴ�.
    /// </summary>
    public void ChooseHat(GameObject hatPrefab)
    {
        SelectedHatPrefab = hatPrefab;
    }

    /// <summary>
    /// ���� ������ �ʱ�ȭ�մϴ�.
    /// </summary>
    public void ResetCustomization()
    {
        SelectedHatPrefab = null;
    }

    /// <summary>
    /// UI ��ư OnClick �̺�Ʈ�� �����Ͽ� ���ڸ� �����ϰ�,
    /// ���� ���� Customizer�� ��� �ݿ��մϴ�.
    /// </summary>
    public void OnSelectHat(GameObject hatPrefab)
    {
        // ���� ���� ����
        ChooseHat(hatPrefab);

        // Ŀ���͸������� �����ϸ� ��� ����
        var customizer = FindObjectOfType<JI_CharacterCustomizer>();
        if (customizer != null)
        {
            customizer.EquipHat(hatPrefab);
        }
    }
}
