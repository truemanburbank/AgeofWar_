using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum UIEvent
    {
        Click,
        Pressed,
        PointerDown,
        PointerUp,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum Scene
    {
        Unknown,
        Main,
        Game,
    }

    public enum State
    {
        Idle,
        AttackA,
        AttackB,
        Walk,
        Dead,
        Hit,
        Heal,
    }

    public enum Layer
    {
        Enemy = 6,
        Our = 7,
        Castle = 8,
    }

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard,
    }
}
