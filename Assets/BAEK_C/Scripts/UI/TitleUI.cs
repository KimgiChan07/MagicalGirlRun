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
    
    public override void Init()
    {

        startButton.onClick.AddListener(() => OnStart());
        exitButton.onClick.AddListener(() => OnStart());
        fakeExitButton.onClick.AddListener(() => OnStart());
    }

    public void OnStart()
    {
        LoadStartScene();
    }

    void LoadStartScene()
    {
        bool tutorialDone = PlayerPrefs.GetInt("TutorialCompleted", 0) == 1;

        if (tutorialDone)
        {
            SceneManager.LoadScene("StageSelectScene");
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
        }
    }


}
