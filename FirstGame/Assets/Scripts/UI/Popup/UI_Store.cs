using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class UI_Store : UI_Popup
{
    public int knightUpgradeLvl = 0;
    public int assassinUpgradeLvl = 0;
    public int archerUpgradeLvl = 0;
    public int healUpgradeLvl = 0;
    public int meteorUpgradeLvl = 0;
    public int buffUpgradeLvl = 0;
    public int[] knightUpgradeReqGold = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
    public int[] assassinUpgradeReqGold = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
    public int[] archerUpgradeReqGold = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
    public int[] healUpgradeReqGold = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
    public int[] meteorUpgradeReqGold = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
    public int[] buffUpgradeReqGold = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
    GameManager _game;

    enum Buttons
    {
        CloseButton,
        KnightUpgradeButton,
        ArcherUpgradeButton,
        AssassinUpgradeButton,
        UnitUpgradeTabButton,
        SkillUpgradeTabButton,
        HealUpgradeButton,
        MeteorUpgradeButton,
        BuffUpgradeButton,
    }

    enum Texts
    {
        KnightContext,
        ArcherContext,
        AssassinContext,
        KnightUpgradePrice,
        ArcherUpgradePrice,
        AssassinUpgradePrice,
        HealContext,
        MeteorContext,
        BuffContext,
        HealUpgradePrice,
        MeteorUpgradePrice,
        BuffUpgradePrice,
    }

    enum GameObjects
    {
        UnitUpgradeTab,
        SkillUpgradeTab,
    }

    public enum PlayTab
    {
        Unit,
        Skill,
    }

    PlayTab _tab = PlayTab.Unit;

    private void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _game = Managers.Game;

        knightUpgradeLvl = _game.knightUpgradeLvl;
        assassinUpgradeLvl = _game.assassinUpgradeLvl;
        archerUpgradeLvl = _game.archerUpgradeLvl;
        healUpgradeLvl = _game.healUpgradeLvl;
        meteorUpgradeLvl = _game.meteorUpgradeLvl;
        buffUpgradeLvl = _game.buffUpgradeLvl;

        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
        BindObject(typeof(GameObjects));

        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(Exit);

        GetButton((int)Buttons.KnightUpgradeButton).gameObject.BindEvent(upgradeKnight);
        GetButton((int)Buttons.ArcherUpgradeButton).gameObject.BindEvent(upgradeArcher);
        GetButton((int)Buttons.AssassinUpgradeButton).gameObject.BindEvent(upgradeAssassin);

        GetButton((int)Buttons.HealUpgradeButton).gameObject.BindEvent(upgradeHeal);
        GetButton((int)Buttons.MeteorUpgradeButton).gameObject.BindEvent(upgradeMeteor);
        GetButton((int)Buttons.BuffUpgradeButton).gameObject.BindEvent(upgradeBuff);

        GetButton((int)Buttons.UnitUpgradeTabButton).gameObject.BindEvent(() => ShowTab(PlayTab.Unit));
        GetButton((int)Buttons.SkillUpgradeTabButton).gameObject.BindEvent(() => ShowTab(PlayTab.Skill));
        GetObject((int)GameObjects.UnitUpgradeTab).gameObject.SetActive(true);
        GetObject((int)GameObjects.SkillUpgradeTab).gameObject.SetActive(false);
        GetButton((int)Buttons.SkillUpgradeTabButton).image.color = Color.gray;

        RefreshUI();
        return true;
    }

    private void Update()
    {

    }

    public void upgradeKnight()
    {
        if (knightUpgradeLvl == knightUpgradeReqGold.Length)
            return;
        // hp += 2
        // dmg += 1
        // def += 1
        int gold = Managers.Game.myGold;
        int ReqGold = knightUpgradeReqGold[knightUpgradeLvl];
        if (gold < ReqGold)
            return;         // 골드가 부족하면 업그레이드 불가능

        Managers.Game.myGold -= ReqGold;
        Managers.Sound.Play("Sound_Upgrade");

        GameManager _game = Managers.Game;

        _game.knightMaxHp += 2;
        _game.knightAttack += 1;
        _game.knightDefence += 1;
        knightUpgradeLvl++;

        RefreshUI();
    }
    public void upgradeAssassin()
    {
        if (assassinUpgradeLvl == assassinUpgradeReqGold.Length)
            return;         // 최대 레벨에 도달
        int gold = Managers.Game.myGold;
        int ReqGold = assassinUpgradeReqGold[assassinUpgradeLvl];
        if (gold < ReqGold)
            return;         // 골드가 부족하면 업그레이드 불가능
        Managers.Game.myGold -= ReqGold;
        Managers.Sound.Play("Sound_Upgrade");

        GameManager _game = Managers.Game;

        _game.assassinMaxHp += 2;
        _game.assassinAttack += 1;
        _game.assassinDefence += 1;
        assassinUpgradeLvl++;

        RefreshUI();
    }
    public void upgradeArcher()
    {
        if (archerUpgradeLvl == archerUpgradeReqGold.Length)
            return;         // 최대 레벨에 도달
        int gold = Managers.Game.myGold;
        int ReqGold = archerUpgradeReqGold[archerUpgradeLvl];
        if (gold < ReqGold)
            return;         // 골드가 부족하면 업그레이드 불가능

        Managers.Game.myGold -= ReqGold;
        Managers.Sound.Play("Sound_Upgrade");

        GameManager _game = Managers.Game;

        _game.archerMaxHp += 2;
        _game.archerAttack += 1;
        _game.archerDefence += 1;
        archerUpgradeLvl++;

        RefreshUI();
    }

    public void upgradeHeal()
    {
        if (healUpgradeLvl == healUpgradeReqGold.Length)
            return;         // 최대 레벨에 도달
        int gold = Managers.Game.myGold;
        int ReqGold = healUpgradeReqGold[healUpgradeLvl];
        if (gold < ReqGold)
            return;         // 골드가 부족하면 업그레이드 불가능
        Managers.Game.myGold -= ReqGold;

        GameManager _game = Managers.Game;

        _game.Unitheal += 1;                                // 유닛 회복량 1씩 증가
        _game.CastleHeal += _game.UnitOnly ? 0 : 10;        // 성 회복량 10씩 증가

        healUpgradeLvl++;
        if (healUpgradeLvl > _game.SpecialHealLvl && _game.UnitOnly == true)
            _game.UnitOnly = false;
        // UnitOnly 레벨을 넘기면, 그때부터 업그레이드는 성의 회복량도 강화한다
        RefreshSkillTexts();
    }
    public void upgradeMeteor()
    {
        if (meteorUpgradeLvl == meteorUpgradeReqGold.Length)
            return;         // 최대 레벨에 도달
        int gold = Managers.Game.myGold;
        int ReqGold = meteorUpgradeReqGold[meteorUpgradeLvl];
        if (gold < ReqGold)
            return;         // 골드가 부족하면 업그레이드 불가능
        Managers.Game.myGold -= ReqGold;

        GameManager _game = Managers.Game;

        _game.Damage += 1;                              // 메테오 데미지 1씩 증가

        meteorUpgradeLvl++;
        if (meteorUpgradeLvl > _game.SpecialMeteorLvl && _game.KillAll == true)
            _game.KillAll = false;
        // KillAll 레벨을 넘기면, 그때부터는 아군 유닛에게 피해를 입히지 않는다

        RefreshSkillTexts();
    }
    public void upgradeBuff()
    {
        if (buffUpgradeLvl == buffUpgradeReqGold.Length)
            return;         // 최대 레벨에 도달
        int gold = Managers.Game.myGold;
        int ReqGold = buffUpgradeReqGold[buffUpgradeLvl];
        if (gold < ReqGold)
            return;         // 골드가 부족하면 업그레이드 불가능
        Managers.Game.myGold -= ReqGold;

        GameManager _game = Managers.Game;

        _game.Duration += 1.0f;     // 버프의 지속시간이 1초씩 증가

        buffUpgradeLvl++;
        RefreshSkillTexts();
    }

    public void RefreshUI()
    {
        RefreshUnitTexts();
        RefreshSkillTexts();
    }

    public void RefreshUnitTexts()
    {
        GameManager _game = Managers.Game;
        int kMaxHp = _game.knightMaxHp;
        int kAttack = _game.knightAttack;
        int kDefence = _game.knightDefence;

        int assMaxHp = _game.assassinMaxHp;
        int assAttack = _game.assassinAttack;
        int assDefence = _game.assassinDefence;

        int arMaxHp = _game.archerMaxHp;
        int arAttack = _game.archerAttack;
        int arDefence = _game.archerDefence;

        GetText((int)Texts.KnightContext).text = (knightUpgradeLvl >= knightUpgradeReqGold.Length) ? "MaxLvl" : $"HP : {kMaxHp} --> {kMaxHp + 2}\r\nDMG : {kAttack} --> {kAttack + 1}\r\nDEF : {kDefence} --> {kDefence + 1}";
        GetText((int)Texts.AssassinContext).text = (assassinUpgradeLvl >= assassinUpgradeReqGold.Length) ? "MaxLvl" : $"HP : {assMaxHp} --> {assMaxHp + 2}\r\nDMG : {assAttack} --> {assAttack + 1}\r\nDEF : {assDefence} --> {assDefence + 1}";
        GetText((int)Texts.ArcherContext).text = (archerUpgradeLvl >= archerUpgradeReqGold.Length) ? "MaxLvl" : $"HP : {arMaxHp} --> {arMaxHp + 2}\r\nDMG : {arAttack} --> {arAttack + 1}\r\nDEF : {arDefence} --> {arDefence + 1}";
        GetText((int)Texts.KnightUpgradePrice).text = (knightUpgradeLvl >= knightUpgradeReqGold.Length) ? "MaxLvl" : $"{knightUpgradeReqGold[knightUpgradeLvl]}";
        GetText((int)Texts.AssassinUpgradePrice).text = (assassinUpgradeLvl >= assassinUpgradeReqGold.Length) ? "MaxLvl" : $"{assassinUpgradeReqGold[assassinUpgradeLvl]}";
        GetText((int)Texts.ArcherUpgradePrice).text = (archerUpgradeLvl >= archerUpgradeReqGold.Length) ? "MaxLvl" : $"{archerUpgradeReqGold[archerUpgradeLvl]}";

    }
    public void RefreshSkillTexts()
    {
        GameManager _game = Managers.Game;
        int unitHeal = _game.Unitheal;
        int castleHeal = _game.CastleHeal;
        string specialH = _game.UnitOnly ? "" : $"CastleHeal : {castleHeal} --> {castleHeal + 10}";

        int damage = _game.Damage;
        string specialM = _game.KillAll ? "" : "[Enemy Only]";

        float duration = _game.Duration;
        GetText((int)Texts.HealContext).text = (healUpgradeLvl >= healUpgradeReqGold.Length) ? "MaxLvl" : $"UnitHeal : {unitHeal} --> {unitHeal + 2}\r\n" + specialH;
        GetText((int)Texts.MeteorContext).text = (meteorUpgradeLvl >= meteorUpgradeReqGold.Length) ? "MaxLvl" : $"DMG : {damage} --> {damage + 1}\r\n" + specialM;
        GetText((int)Texts.BuffContext).text = (buffUpgradeLvl >= buffUpgradeReqGold.Length) ? "MaxLvl" : $"Duration : {duration} --> {duration + 1.0f}\r\n";
        GetText((int)Texts.HealUpgradePrice).text = (healUpgradeLvl >= healUpgradeReqGold.Length) ? "MaxLvl" : $"{healUpgradeReqGold[healUpgradeLvl]}";
        GetText((int)Texts.MeteorUpgradePrice).text = (meteorUpgradeLvl >= meteorUpgradeReqGold.Length) ? "MaxLvl" : $"{meteorUpgradeReqGold[meteorUpgradeLvl]}";
        GetText((int)Texts.BuffUpgradePrice).text = (buffUpgradeLvl >= buffUpgradeReqGold.Length) ? "MaxLvl" : $"{buffUpgradeReqGold[buffUpgradeLvl]}";

    }

    public void ShowTab(PlayTab tab)
    {
        _tab = tab;

        GetObject((int)GameObjects.UnitUpgradeTab).gameObject.SetActive(false);
        GetObject((int)GameObjects.SkillUpgradeTab).gameObject.SetActive(false);

        switch (_tab)
        {
            case PlayTab.Unit :
                GetObject((int)GameObjects.UnitUpgradeTab).gameObject.SetActive(true);
                GetButton((int)Buttons.UnitUpgradeTabButton).image.color = Color.white;
                GetButton((int)Buttons.SkillUpgradeTabButton).image.color = Color.gray;
                break;
            case PlayTab.Skill :
                GetObject((int)GameObjects.SkillUpgradeTab).gameObject.SetActive(true);
                GetButton((int)Buttons.UnitUpgradeTabButton).image.color = Color.gray;
                GetButton((int)Buttons.SkillUpgradeTabButton).image.color = Color.white;
                break;
        }

    }

    void Exit()
    {
        Debug.Log("뒤로 가기");
        IsPause = true;
        PauseChecker();
        ClosePopupUI();

        _game = Managers.Game;

        _game.knightUpgradeLvl = knightUpgradeLvl;
        _game.assassinUpgradeLvl = assassinUpgradeLvl;
        _game.archerUpgradeLvl = archerUpgradeLvl;
        _game.healUpgradeLvl = healUpgradeLvl;
        _game.meteorUpgradeLvl = meteorUpgradeLvl;
        _game.buffUpgradeLvl = buffUpgradeLvl;
    }
}
