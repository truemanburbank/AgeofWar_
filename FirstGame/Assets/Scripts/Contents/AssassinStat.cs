using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassinStat : Stat
{
    private void Awake()
    {
        _hp = Managers.Game.assassinMaxHp;
        _maxHp = Managers.Game.assassinMaxHp;
        _attack = Managers.Game.assassinAttack;
        _attackSpeed = Managers.Game.assassinAttackSpeed;
        _defence = Managers.Game.assassinDefence;
        _moveSpeed = Managers.Game.assassinMoveSpeed;
        _reqGold = Managers.Game.assassinReqGold;
        _dropGold = Managers.Game.assassinDropGold;
        _range = Managers.Game.assassinRange;
    }
}
