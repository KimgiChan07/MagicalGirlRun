using TMPro;
using UnityEngine;
using System.Collections;
public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialCharacter;
    public TextMeshProUGUI tutorialText;

    private int tutorialStep = 0;
    private bool TutorialActive = true;

    void Start()
    {
        tutorialCharacter.SetActive(true);
        ShowMessage("�����̽��ٷ� ������ �� �ֵ��� �մϴ�. �ǽ�");
    }

    void Update()
    {
        if (!TutorialActive) return;

        if (tutorialStep == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            ShowMessage("�̹��� Shift�� �����̵��� ������ �մϴ�.");
            tutorialStep++;
        }
        else if (tutorialStep == 1 && Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.RightShift))
        {
            ShowMessage("����, ������ �����ҳ෱�� �°� ȯ���Ѵ�");
            tutorialStep++;
        }
        else if (tutorialStep == 2)
        {
            StartCoroutine(EndTutorial());
            tutorialStep++;
        }
    }

    void ShowMessage(string message)
    {
        tutorialText.text = message;
    }
   
    IEnumerator EndTutorial()
    {
        yield return new WaitForSeconds(1f);
        tutorialCharacter.SetActive(false);

        TutorialActive = false;

        // ���⼭ ���� ���� ���� ����
        Debug.Log("Ʃ�丮�� �� �� ���� ����!");
    }
}
