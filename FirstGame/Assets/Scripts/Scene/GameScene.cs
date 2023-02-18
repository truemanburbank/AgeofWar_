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
        // ����ȭ�� â�� ����ϴ� UI�� �ҷ��� ��
        Managers.UI.ShowSceneUI<UI_Game>();
        Debug.Log("Init");
        return true;
    }
}
