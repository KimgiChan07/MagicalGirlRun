using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class BadEndingManager : MonoBehaviour
{
    public TextMeshProUGUI badendingText; 
    public TextMeshProUGUI characterNameText; 
    public Image characterImage; 
    public Button nextButton; 

    public string[] dialogue = {
        "�����ҳ� 1: ",
        "�����ҳ� 2: ",
        "�����ҳ� 3: ",
        "���ΰ�: "

    }; 
    public string[] characterNames = {
        "�����ҳ� 1",
        "�����ҳ� 2",
        "�����ҳ� 3",
        "���ΰ�"}; // ĳ���� �̸�
    public Sprite[] characterSprites = { 
    }; //ĳ�����̹���

    private int currentDialogueIndex = 0; //���� ���

    void Start()
    {
        nextButton.onClick.AddListener(OnNextText);
        ShowText();  // ù��°���
    }

    //��� ���
    void ShowText()
    {
        if (currentDialogueIndex < dialogue.Length)
        {
            badendingText.text = dialogue[currentDialogueIndex];  
            characterNameText.text = characterNames[currentDialogueIndex]; 
            characterImage.sprite = characterSprites[currentDialogueIndex];  
        }
        else
        {
            
            Ending();
        }
    }

    //���� ����
    void OnNextText()
    {
        currentDialogueIndex++;  
        ShowText(); 
    }

    //��簡 ������ ���� ó���� �� �̵�
    void Ending()
    {
       
    
      //SceneManager.LoadScene("EndingScene");
    }
}
