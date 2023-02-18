using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class UI_Win : UI_Popup
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
        WinText,
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
        Managers.Sound.Play("Sound_Win");

        return _init = true;
    }

    void Retry()
    {
        Debug.Log("Win and Retry");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");

        // ������ ��ȭ �ʱ�ȭ
        Managers.Game.Init();

    }

    void Exit() 
    {
        Debug.Log("����!");
        Application.Quit();
    }

}
