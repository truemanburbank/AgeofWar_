using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using static Define;

[Serializable]
public class GameData
{
    #region 스탯
    public int MyHp;
    public int MyMaxHp;
    public int EnemyHp;
    public int EnemyMaxHp;
    public int difficulty;
    #endregion

    #region 재화
    public int myGold;
    public int enemyGold;
    #endregion
}
public class knightUnitStat
{
    #region 유닛 스탯
    public int knightMaxHp;
    public int knightAttack;
    public float knightAttackSpeed;
    public int knightDefence;
    public float knightMoveSpeed;
    public int knightReqGold;
    public int knightDropGold;
    public float knightRange;
    #endregion
}
public class assassinUnitStat
{
    #region 유닛 스탯
    public int assassinMaxHp;
    public int assassinAttack;
    public float assassinAttackSpeed;
    public int assassinDefence;
    public float assassinMoveSpeed;
    public int assassinReqGold;
    public int assassinDropGold;
    public float assassinRange;
    #endregion
}
public class archerUnitStat
{
    #region 유닛 스탯
    public int archerMaxHp;
    public int archerAttack;
    public float archerAttackSpeed;
    public int archerDefence;
    public float archerMoveSpeed;
    public int archerReqGold;
    public int archerDropGold;
    public float archerRange;
    #endregion
}
public class HealStat
{
    public int unitHeal;
    public int specialHealLvl;
    public bool unitOnly;
    public int castleHeal;
}
public class MeteorStat 
{
    public int damage;
    public int specialMeteorLvl;
    public bool killall;
}
public class BuffStat
{
    public float duration;
}
public class UpgradeStat
{
    public int knightUpgradeLvl;
    public int assassinUpgradeLvl;
    public int archerUpgradeLvl;
    public int healUpgradeLvl;
    public int meteorUpgradeLvl;
    public int buffUpgradeLvl;
}
public class GameManager
{
    GameData _gameData = new GameData();

    #region 스탯
    public int MyHp
    {
        get { return _gameData.MyHp; }
        set { _gameData.MyHp = Mathf.Clamp(value, 0, MyMaxHp); }
    }

    public int MyMaxHp
    {
        get { return _gameData.MyMaxHp; }
        set { _gameData.MyMaxHp = value; }
    }

    public float MyHpPercent { get { return MyHp * 100 / (float)MyMaxHp; } }

    public int EnemyHp
    {
        get { return _gameData.EnemyHp; }
        set { _gameData.EnemyHp = Mathf.Clamp(value, 0, EnemyMaxHp); }
    }

    public int EnemyMaxHp
    {
        get { return _gameData.EnemyMaxHp; }
        set { _gameData.EnemyMaxHp = value; }
    }

    public float EnemyHpPercent { get { return (EnemyHp * 100 / (float)EnemyMaxHp); } }

    public int difficulty
    {
        get { return _gameData.difficulty; }
        set { _gameData.difficulty = value; }
    }

    #endregion

    #region 재화
    public int myGold
    {
        get { return _gameData.myGold; }
        set { _gameData.myGold = value; }
    }

    public int enemyGold
    {
        get { return _gameData.enemyGold; }
        set { _gameData.enemyGold = value; }
    }
    #endregion

    knightUnitStat _knightUnitStat = new knightUnitStat();

    #region 유닛 스탯
    public int knightMaxHp
    {
        get { return _knightUnitStat.knightMaxHp; }
        set { _knightUnitStat.knightMaxHp = value; }
    }

    public int knightAttack
    {
        get { return _knightUnitStat.knightAttack; }
        set { _knightUnitStat.knightAttack = value; }
    }

    public float knightAttackSpeed
    {
        get { return _knightUnitStat.knightAttackSpeed; }
        set { _knightUnitStat.knightAttackSpeed = value; }
    }

    public int knightDefence
    {
        get { return _knightUnitStat.knightDefence; }
        set { _knightUnitStat.knightDefence = value; }
    }

    public float knightMoveSpeed
    {
        get { return _knightUnitStat.knightMoveSpeed; }
        set { _knightUnitStat.knightMoveSpeed = value; }
    }

    public int knightReqGold
    {
        get { return _knightUnitStat.knightReqGold; }
        set { _knightUnitStat.knightReqGold = value; }
    }

    public int knightDropGold
    {
        get { return _knightUnitStat.knightDropGold; }
        set { _knightUnitStat.knightDropGold = value; }
    }

    public float knightRange
    {
        get { return _knightUnitStat.knightRange; }
        set { _knightUnitStat.knightRange = value; }
    }
    #endregion

    assassinUnitStat _assassinUnitStat = new assassinUnitStat();

    #region 유닛 스탯
    public int assassinMaxHp
    {
        get { return _assassinUnitStat.assassinMaxHp; }
        set { _assassinUnitStat.assassinMaxHp = value; }
    }

    public int assassinAttack
    {
        get { return _assassinUnitStat.assassinAttack; }
        set { _assassinUnitStat.assassinAttack = value; }
    }

    public float assassinAttackSpeed
    {
        get { return _assassinUnitStat.assassinAttackSpeed; }
        set { _assassinUnitStat.assassinAttackSpeed = value; }
    }

    public int assassinDefence
    {
        get { return _assassinUnitStat.assassinDefence; }
        set { _assassinUnitStat.assassinDefence = value; }
    }

    public float assassinMoveSpeed
    {
        get { return _assassinUnitStat.assassinMoveSpeed; }
        set { _assassinUnitStat.assassinMoveSpeed = value; }
    }

    public int assassinReqGold
    {
        get { return _assassinUnitStat.assassinReqGold; }
        set { _assassinUnitStat.assassinReqGold = value; }
    }

    public int assassinDropGold
    {
        get { return _assassinUnitStat.assassinDropGold; }
        set { _assassinUnitStat.assassinDropGold = value; }
    }

    public float assassinRange
    {
        get { return _assassinUnitStat.assassinRange; }
        set { _assassinUnitStat.assassinRange = value; }
    }
    #endregion

    archerUnitStat _archerUnitStat = new archerUnitStat();

    #region 유닛 스탯
    public int archerMaxHp
    {
        get { return _archerUnitStat.archerMaxHp; }
        set { _archerUnitStat.archerMaxHp = value; }
    }

    public int archerAttack
    {
        get { return _archerUnitStat.archerAttack; }
        set { _archerUnitStat.archerAttack = value; }
    }

    public float archerAttackSpeed
    {
        get { return _archerUnitStat.archerAttackSpeed; }
        set { _archerUnitStat.archerAttackSpeed = value; }
    }

    public int archerDefence
    {
        get { return _archerUnitStat.archerDefence; }
        set { _archerUnitStat.archerDefence = value; }
    }

    public float archerMoveSpeed
    {
        get { return _archerUnitStat.archerMoveSpeed; }
        set { _archerUnitStat.archerMoveSpeed = value; }
    }

    public int archerReqGold
    {
        get { return _archerUnitStat.archerReqGold; }
        set { _archerUnitStat.archerReqGold = value; }
    }

    public int archerDropGold
    {
        get { return _archerUnitStat.archerDropGold; }
        set { _archerUnitStat.archerDropGold = value; }
    }

    public float archerRange
    {
        get { return _archerUnitStat.archerRange; }
        set { _archerUnitStat.archerRange = value; }
    }
    #endregion

    #region Skills

    // Skill1
    HealStat _healStat = new HealStat();
    public int Unitheal
    {
        get { return _healStat.unitHeal; }
        set { _healStat.unitHeal = value; }
    }
    public int SpecialHealLvl
    {
        get { return _healStat.specialHealLvl; }
        set { _healStat.specialHealLvl = value; }
    }
    public bool UnitOnly
    {
        get { return _healStat.unitOnly; }
        set { _healStat.unitOnly = value; }
    }
    public int CastleHeal
    {
        get { return _healStat.castleHeal; }
        set { _healStat.castleHeal = value; }
    }

    // Skill2
    MeteorStat _meteorStat = new MeteorStat();
    public int Damage
    {
        get { return _meteorStat.damage; }
        set { _meteorStat.damage = value; }
    }
    public int SpecialMeteorLvl
    {
        get { return _meteorStat.specialMeteorLvl; }
        set { _meteorStat.specialMeteorLvl = value; }

    }
    public bool KillAll
    {
        get { return _meteorStat.killall; }
        set { _meteorStat.killall = value; }

    }

    // Skill3
    BuffData _buffData = new BuffData();
    public float Duration
    {
        get { return _buffData.duration; }
        set { _buffData.duration = value; }
    }

    #endregion

    #region upgrade
    UpgradeStat _upgradeStat = new UpgradeStat();
    public int knightUpgradeLvl
    {
        get { return _upgradeStat.knightUpgradeLvl; }
        set { _upgradeStat.knightUpgradeLvl = value; }
    }
    public int assassinUpgradeLvl
    {
        get { return _upgradeStat.assassinUpgradeLvl; }
        set { _upgradeStat.assassinUpgradeLvl = value; }
    }
    public int archerUpgradeLvl
    {
        get { return _upgradeStat.archerUpgradeLvl; }
        set { _upgradeStat.archerUpgradeLvl = value; }
    }
    public int healUpgradeLvl
    {
        get { return _upgradeStat.healUpgradeLvl; }
        set { _upgradeStat.healUpgradeLvl = value; }
    }
    public int meteorUpgradeLvl
    {
        get { return _upgradeStat.meteorUpgradeLvl; }
        set { _upgradeStat.meteorUpgradeLvl = value; }
    }
    public int buffUpgradeLvl
    {
        get { return _upgradeStat.buffUpgradeLvl; }
        set { _upgradeStat.buffUpgradeLvl = value; }

    }
    #endregion

    public void Init()
    {
        #region 시작 데이터
        StartData data = Managers.Data.Start;

        MyHp = data.myMaxHp;
        MyMaxHp = data.myMaxHp;
        EnemyHp = data.enemyMaxHp;
        EnemyMaxHp = data.enemyMaxHp;

        myGold = data.myGold;
        enemyGold = data.enemyGold;
        difficulty = data.difficulty;

        MyHp = MyMaxHp;
        EnemyHp = EnemyMaxHp;
        #endregion

        #region knightStat
        KnightStatData knightStat = Managers.Data.KnightStat;

        knightMaxHp = knightStat.maxHp;
        knightAttack = knightStat.attack;
        knightAttackSpeed = knightStat.attackSpeed;
        knightDefence = knightStat.defence;
        knightMoveSpeed = knightStat.moveSpeed;
        knightReqGold = knightStat.reqGold;
        knightDropGold = knightStat.dropGold;
        knightRange = knightStat.range;
        #endregion

        #region assassinStat
        AssassinStatData assassinStat = Managers.Data.AssassinStat;

        assassinMaxHp = assassinStat.maxHp;
        assassinAttack = assassinStat.attack;
        assassinAttackSpeed = assassinStat.attackSpeed;
        assassinDefence = assassinStat.defence;
        assassinMoveSpeed = assassinStat.moveSpeed;
        assassinReqGold = assassinStat.reqGold;
        assassinDropGold = assassinStat.dropGold;
        assassinRange = assassinStat.range;
        #endregion

        #region archerStat
        ArcherStatData archerStat = Managers.Data.ArchorStat;

        archerMaxHp = archerStat.maxHp;
        archerAttack = archerStat.attack;
        archerAttackSpeed = archerStat.attackSpeed;
        archerDefence = archerStat.defence;
        archerMoveSpeed = archerStat.moveSpeed;
        archerReqGold= archerStat.reqGold;
        archerDropGold= archerStat.dropGold;
        archerRange = archerStat.range;
        #endregion

        #region Skills

        // Skill1
        HealData healData = Managers.Data.HealStat;
        Unitheal = healData.unitHeal;
        UnitOnly = healData.unitOnly;
        SpecialHealLvl = healData.specialHealLvl;
        CastleHeal = healData.castleHeal;

        // Skill2
        MeteorData meteorData = Managers.Data.MeteorStat;
        Damage = meteorData.damage;
        SpecialMeteorLvl = meteorData.specialMeteorLvl;
        KillAll = meteorData.killAll;

        // Skill3
        BuffData buffData = Managers.Data.BuffStat;
        Duration = buffData.duration;

        #endregion

        #region upgrade
        UpgradeData upgradeData= Managers.Data.UpgradeStat;

        knightUpgradeLvl = upgradeData.knightUpgradeLvl;
        assassinUpgradeLvl = upgradeData.assassinUpgradeLvl;
        archerUpgradeLvl = upgradeData.archerUpgradeLvl;
        healUpgradeLvl = upgradeData.healUpgradeLvl;
        meteorUpgradeLvl = upgradeData.meteorUpgradeLvl;
        buffUpgradeLvl = upgradeData.buffUpgradeLvl;
        #endregion
    }

}