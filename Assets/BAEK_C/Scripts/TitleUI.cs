using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class TitleUI : UIManagerBase
{  

    public Button startButton;
    public Button quitButton;
    public Button fakeQuitButton;
    public VideoPlayer videoPlayer;

    public override void Init()
    {
        startButton.onClick.AddListener(OnStart);
        quitButton.onClick.AddListener(OnExit);
        fakeQuitButton.onClick.AddListener(OnFakeExit);

        videoPlayer.Play();  // ��� ���� ���
    }

    private void OnStart()
    {
        Debug.Log("���� ����!");
        Hide();
        // �� ��ȯ �Ǵ� StageSelectUI.Show() ȣ��
    }

    private void OnExit()
    {
        Debug.Log("���� ���� �õ�");
        Application.Quit();
    }

    private void OnFakeExit()
    {
        Debug.Log("��� ����! ��¥ ����!");
       
    }
}
