using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JI_GM : MonoBehaviour
{
    public static JI_GM Instance { get; private set; }

    // ������ ������ ���� ������
    public GameObject SelectedHatPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }
}
