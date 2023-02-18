using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.Scene.Main;
        Managers.UI.ShowSceneUI<UI_Main>();
        Debug.Log("Init");
        return true;
    }
}
