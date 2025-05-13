
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questUI;

    [Header("���� ��������")]
    // �������� ����Ʈ ����
    public static bool isQuestClear;
    public static bool onQuest;

    [Header("�䱸��, ������")]
    [SerializeField] private int demand = 5;
    [SerializeField] private int reserves = 0;

    void Start()
    {
        Debug.Log($"����Ʈ Ȱ��ȭ");
        onQuest = true;
        isQuestClear = false;
        OnQuestUI();
    }

    public void GetQuestItem() // ����Ʈ ������ ����
    {
        reserves ++;

        OnQuestUI();

        if (onQuest && demand <= reserves)
        {
            QuestComplete();
        }
    }

    private void QuestComplete() // ����Ʈ �Ϸ�
    {
        questUI.text = $"����Ʈ ������ ����\n-���� �Ϸ�-";
        isQuestClear = true;
        onQuest = false;
        reserves = 0;
    }

    private void OnQuestUI() // ����Ʈ ��Ȳ ǥ��
    {
        if (onQuest == false) { return; }

        questUI.text = $"����Ʈ ������ ����\n{reserves}/{demand}";
    }
}
