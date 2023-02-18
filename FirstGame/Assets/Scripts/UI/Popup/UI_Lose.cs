using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class UI_Lose : UI_Popup
{
    enum Buttons
    {
        RetryBtn,
        ExitBtn,
    }

    enum Texts
    {
        RetryText,
        ExitText,
        LoseText,
    }

    private void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (_init)
            return false;

        BindButton(typeof(Buttons));
        BindText(typeof(Texts));

        GetButton((int)Buttons.RetryBtn).gameObject.BindEvent(Retry);
        GetButton((int)Buttons.ExitBtn).gameObject.BindEvent(Exit);

        Managers.Sound.Clear();
        Managers.Sound.Play("Sound_Lose");

        return _init = true;
    }

    void Retry()
    {
        Debug.Log("Lose and Retry");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");

        // 기존의 재화 초기화
        Managers.Game.Init();
    }

    void Exit()
    {
        Debug.Log("종료!");
        Application.Quit();
    }
}
