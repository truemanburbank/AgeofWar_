using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherStat : Stat
{
    private void Awake()
    {
        _hp = Managers.Game.archerMaxHp;
        _maxHp = Managers.Game.archerMaxHp;
        _attack = Managers.Game.archerAttack;
        _attackSpeed = Managers.Game.archerAttackSpeed;
        _defence = Managers.Game.archerDefence;
        _moveSpeed = Managers.Game.archerMoveSpeed;
        _reqGold = Managers.Game.archerReqGold;
        _dropGold = Managers.Game.archerDropGold;
        _range = Managers.Game.archerRange;
    }
}
