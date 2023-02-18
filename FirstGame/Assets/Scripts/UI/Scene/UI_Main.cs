using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Main : UI_Scene
{
    enum Buttons
    {
        GameStart,
        QuitGame,
        Easy,
        Normal,
        Hard,
    }

    enum Texts
    {
        GameStartText,
        QuitGameText,
        EasyText,
        NormalText,
        HardText,
    }

    private void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));
        BindText(typeof(Texts));

        GetButton((int)Buttons.GameStart).gameObject.BindEvent(ToGameScene);
        GetButton((int)Buttons.QuitGame).gameObject.BindEvent(QuitGame);
        GetButton((int)Buttons.Easy).gameObject.BindEvent(Easy);
        GetButton((int)Buttons.Normal).gameObject.BindEvent(Normal);
        GetButton((int)Buttons.Hard).gameObject.BindEvent(Hard);

        return true;
    }

    void ToGameScene()
    {
        // 게임 시작
        Debug.Log("게임 시작!");
        Managers.Sound.Play("Sound_OpenUI");

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        Managers.UI.ShowSceneUI<UI_Game>();
    }

    void QuitGame()
    {
        //  게임 나가기!
        Debug.Log("게임 나가기!");
        Application.Quit();
    }

    void Easy()
    {
        Managers.Game.difficulty = (int)Define.Difficulty.Easy;
    }

    void Normal()
    {
        Managers.Game.difficulty = (int)Define.Difficulty.Normal;
    }

    void Hard()
    {
        Managers.Game.difficulty = (int)Define.Difficulty.Hard;
    }
}
