using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JI_Test : MonoBehaviour
{
    [Header("ĳ���� Ŀ���͸����� ������Ʈ")]
    private JI_CharacterCustomizer customizer;

    private JI_PlayerController playerController;
    private void Awake()
    {
        // JI_CharacterCustomizer ������Ʈ ��������
        customizer = FindObjectOfType<JI_CharacterCustomizer>();
        // JI_PlayerController ������Ʈ ��������
        playerController = FindObjectOfType<JI_PlayerController>();
    }
    private void Start()
    {
        playerController.IsStop();
    }
    public void OnClickEquipHat(GameObject hatPrefab)
    {
        JI_GM.Instance.SelectedHatPrefab = hatPrefab;
        customizer.EquipHat(hatPrefab);
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("JI_Scene");
    }

}
