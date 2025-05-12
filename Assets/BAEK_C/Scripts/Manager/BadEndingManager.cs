using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BadEndingManager : MonoBehaviour
{
    public TextMeshProUGUI leftNameText;           // ���� ĳ���� �̸� �ؽ�Ʈ
    public TextMeshProUGUI rightNameText;          // ������ ĳ���� �̸� �ؽ�Ʈ
    public TextMeshProUGUI badstoryText;           // ��� �ؽ�Ʈ
   
    public GameObject Panel;    // ��ȭ �г�
    public Button Button;           // ��� ���� ��ư

    public List<BadStoryLine> badstoryline;    // ��� ����Ʈ
    private int currentIndex = 0;       // ���� ��� �ε���

    void Start()
    {
        // ��� ����Ʈ�� �����Ϳ��� �߰��Ǿ����� Ȯ��
        

        Button.onClick.AddListener(NextLine); // ��ư Ŭ�� �� ��� ����
        ShowLine();
    }

    // ��� ���
    void ShowLine()
    {
        if (currentIndex >= badstoryline.Count)
        {
            EndDialogue();
            return;
        }

        BadStoryLine line = badstoryline[currentIndex];

        // �̸� �ؽ�Ʈ ����
        if (line.speaker == "Left")
        {
            leftNameText.text = line.speakerName;   // ���� ĳ���� �̸�
            rightNameText.text = "";                // ������ ĳ���� �̸��� �����
        }
        else if (line.speaker == "Right")
        {
            leftNameText.text = "";                // ���� ĳ���� �̸��� �����
            rightNameText.text = line.speakerName;  // ������ ĳ���� �̸�
        }

        badstoryText.text = line.badstoryText;      // ��� �ؽ�Ʈ
        

        Panel.SetActive(true);  // ��ȭ �г� Ȱ��ȭ
    }

    // ��� ����
    void NextLine()
    {
        currentIndex++;
        ShowLine();
    }

    // ��ȭ ����
    void EndDialogue()
    {
        Panel.SetActive(false);  // ��ȭ ���� �� �г� ��Ȱ��ȭ
        // ��ȭ ���� �� �ٸ� ó��
    }

}

[System.Serializable]
public class BadStoryLine
{
    public string speaker;             // � ĳ���Ͱ� ���� �ϴ��� (Left / Right)
    public string speakerName;         // ���ϴ� ����� �̸�
    public string badstoryText;        // ��� ����
   
}
