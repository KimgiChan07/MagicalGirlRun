using UnityEngine;

public class JI_PlayerStats : MonoBehaviour
{
    [Header("�÷��̾� ü��")]
    [SerializeField] private int maxHp = 3; // �ִ� ü�� (���� ����)
    [SerializeField] private int currentHp; // ���� ü�� (���� ����)
    JI_HeartsUI heartsUI; // ��Ʈ UI�� �����ϱ� ���� ����
    public int MaxHp // �ִ� ü�� �ܺο���  ���� ����
    {
        get => maxHp;
        set
        {
            maxHp = Mathf.Max(1, value); // �ּ� 1 �̻����� ����
            // currentHp �ּҰ��� 0, �ִ밪�� maxHp�� ����
            currentHp = Mathf.Clamp(currentHp, 0, maxHp);
            // heartsUI�� null�� �ƴϸ� �ִ� ü�� ���� �� UI ����
            heartsUI?.UpdateHearts();  
        }
    }
    public int CurrentHp // ���� ü�� �ܺο��� ���� ����
    {
        get => currentHp;
        private set
        {
            currentHp = Mathf.Clamp(value, 0, maxHp);
            // heartsUI�� null�� �ƴϸ� ü�� ����� �� UI ����
            heartsUI?.UpdateHearts(); 

        }
    }

    private void Awake()
    {
        currentHp = maxHp;
        heartsUI = FindObjectOfType<JI_HeartsUI>();
      
       
    }
    private void Start()
    {
        // heartsUI�� null�� �ƴϸ� ������ �� UI �ʱ�ȭ
        heartsUI?.UpdateHearts();
    }
    public void Heal(int amount) // ü�� ȸ�� 
    {
        CurrentHp += amount;
    }

    public void TakeDamage(int amount) // ü�� ����
    {
        CurrentHp -= amount;
    }

}
