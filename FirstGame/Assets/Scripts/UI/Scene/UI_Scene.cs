using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
    [SerializeField]
    protected Define.Difficulty _difficulty;
    // Level of Difficulty

    protected virtual Define.Difficulty Difficulty
    {
        get { return _difficulty; }
        set { _difficulty = value; }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Managers.UI.SetCanvas(gameObject, false);
        return true;
    }

}
