using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.Scene.Game;
        // 게임화면 창을 담당하는 UI를 불러야 함
        Managers.UI.ShowSceneUI<UI_Game>();
        Debug.Log("Init");
        return true;
    }
}
