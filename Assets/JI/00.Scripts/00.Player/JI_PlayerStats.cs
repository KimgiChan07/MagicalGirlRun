using UnityEngine;

public class JI_PlayerStats : MonoBehaviour
{
    [Header("�÷��̾� ü��")]
    [SerializeField] private float maxHp = 5f;
    [SerializeField] private float currentHp; // ���� ü��(���� ����)
    public float MaxHp
    {
        get => maxHp;
        set
        {
            maxHp = Mathf.Max(0f, value);// �ִ� ü���� 0 �̻����θ� ����          
            currentHp = Mathf.Clamp(currentHp, 0f, maxHp);// currentHp�� �� maxHp�� ���� �ʵ��� ����
        }
    }
    public float CurrentHp
    {
        get => currentHp;
        private set
        {
            currentHp = Mathf.Clamp(value, 0f, maxHp);
        }
    }
    public void Heal(float amount) => currentHp += amount;
    public void TakeDamage(float amount) => currentHp -= amount;

    private void Awake()
    {
        currentHp = maxHp; // �ʱ� ü�� ����
    }

}