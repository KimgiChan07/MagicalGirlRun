using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUI : BaseUI
{  

    public Button startButton;
    public Button exitButton;
    public Button fakeExitButton;
    public VideoPlayer videoPlayer;

    public override void Init()
    {
       
        startButton.onClick.AddListener(OnStart);
        exitButton.onClick.AddListener(OnExit);
        fakeExitButton.onClick.AddListener(OnFakeExit);

        videoPlayer.Play();  
    }

    public void OnStart()
    {     
        SceneManager.LoadScene("StageSelectScene");

    }

    public void OnExit()
    {
        Debug.Log("���� ����");
        Application.Quit();
    }

    public void OnFakeExit()
    {
        Debug.Log("�ϳ���ó�� �����̾�? �� �����ҳ��");
        SceneManager.LoadScene("StageSelectScene");
    }
}
