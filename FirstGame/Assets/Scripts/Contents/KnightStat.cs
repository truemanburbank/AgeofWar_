using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightStat : Stat
{
    public void Awake()
    {
        _hp = Managers.Game.knightMaxHp;
        _maxHp = Managers.Game.knightMaxHp;
        _attack = Managers.Game.knightAttack;
        _attackSpeed = Managers.Game.knightAttackSpeed;
        _defence = Managers.Game.knightDefence;
        _moveSpeed = Managers.Game.knightMoveSpeed;
        _reqGold = Managers.Game.knightReqGold;
        _dropGold = Managers.Game.knightDropGold;
        _range = Managers.Game.knightRange;
    }
}
