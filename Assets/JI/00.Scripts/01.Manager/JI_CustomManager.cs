using UnityEngine;
public class JI_CustomManager : MonoBehaviour
{
    public static JI_CustomManager Instance { get; private set; }

    public GameObject SelectedHatPrefab { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void ChooseHat(GameObject hatPrefab)
    {
        SelectedHatPrefab = hatPrefab;
    }
    public void ResetCustomization()
    {
        SelectedHatPrefab = null;
    }
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
