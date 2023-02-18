using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
using TMPro;
using Unity.VisualScripting;

public class UI_Game : UI_Scene
{
    #region TODO
    // TODO
    // 세팅 아이콘을 누르면 게임 정지 및 세팅 팝업 창 띄우기 (ShowPopupUI사용?)

    // 골드 재화는 deltaTime에 따라서 올라가기

    // 골드가 충분하고 캐릭터 버튼을 누르면 아무튼 성에서 캐릭터 생성

    // 적이든 유저든 캐릭터가 상대 spawnArea까지 도달하면 성 공격 및 성 체력 관리


    #endregion
    public AudioClip BGM;

    enum Buttons
    {
        Setting,
        KnightBtn,
        ArcherBtn,
        AssassinBtn,
        StoreBtn,
        Skill1Btn,
        Skill2Btn,
        Skill3Btn,
    }

    enum Texts
    {
        GoldText,
        MyHpBarText,
        EnemyHpBarText,
    }

    enum Images
    {
        MyHpBarFill,
        EnemyHpBarFill,
    }

    GameManager _game;

    float playTime = 0.0f;
    float OurPrevIncomeTime;
    float EnemyPrevIncomeTime;
    float goldIncomeInterval = 3.0f;    // 골드 수급 시간간격 - 3초
    float prevSpawnTime;
    float spawnInterval;

    void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _game = Managers.Game;

        OurPrevIncomeTime = playTime;
        EnemyPrevIncomeTime = playTime;

        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
        BindImage(typeof(Images));

        GetButton((int)Buttons.StoreBtn).gameObject.BindEvent(Store);
        GetButton((int)Buttons.Setting).gameObject.BindEvent(Setting);
        Managers.Sound.Play(BGM, Define.Sound.Bgm);
        // == Managers.Sound.Play("BGM/Cotton Candy", Define.Sound.Bgm);

        GetButton((int)Buttons.KnightBtn).gameObject.BindEvent(CreateKnight);
        GetButton((int)Buttons.ArcherBtn).gameObject.BindEvent(CreateArcher);
        GetButton((int)Buttons.AssassinBtn).gameObject.BindEvent(CreateAssassin);

        GetButton((int)Buttons.Skill1Btn).gameObject.BindEvent(Skill1);
        GetButton((int)Buttons.Skill2Btn).gameObject.BindEvent(Skill2);
        GetButton((int)Buttons.Skill3Btn).gameObject.BindEvent(Skill3);

        RefreshUI();

        return true;
    }

    int MyGoldIncome = 100;
    int EnemyGoldIncome = 100;

    void Update()
    {
        playTime += Time.deltaTime;
        StartGame();
        RefreshUI();
        myGoldIncome(MyGoldIncome);
        enemyGoldIncome(EnemyGoldIncome);
        Debug.Log($"Enemy Gold : {Managers.Game.enemyGold}");
    }

    void Setting()
    {
        // 설정 창
        Debug.Log("일시 정지");
        Managers.Sound.Play("Sound_OpenUI");
        IsPause = false;
        Managers.UI.ShowPopupUI<UI_Setting>();
        PauseChecker();
    }

    void Store()
    {
        // 상점 창
        IsPause = false;
        Managers.Sound.Play("Sound_OpenUI");
        Managers.UI.ShowPopupUI<UI_Store>();
        PauseChecker();
    }

    Vector3 spawnArea = new Vector3(-7f, -2.5f, 0);

    void CreateKnight()
    {
        if (_game.myGold < Managers.Game.knightReqGold)
        {
            Debug.Log("기사 출동 실패!");
            Managers.Sound.Play("Sound_Depurchase");
            return;
        }
        Debug.Log("기사 출동!");
        Managers.Sound.Play("Sound_Purchase");
        _game.myGold -= Managers.Game.knightReqGold;
        GameObject go = Managers.Resource.Instantiate("Character/Enemy/EnemyKnight");
        //go.transform.position = new Vector3(-5.5f, -2.5f, 0);\
        go.transform.position = spawnArea;
        go.AddComponent<KnightStat>();
        go.AddComponent<KnightController>();

        //GameObject enemyGo = Managers.Resource.Instantiate("Character/User/EnemyKnight");
        //enemyGo.transform.position = new Vector3(16.5f, -2.5f, 0);
        //enemyGo.AddComponent<KnightStat>();
        //enemyGo.AddComponent<EnemyKnightController>();
        //SpriteRenderer sprite = enemyGo.GetOrAddComponent<SpriteRenderer>();
        //enemyGo.GetComponent<Collider2D>().offset = enemyGo.GetComponent<Collider2D>().offset * new Vector2(-1, 1);
        //sprite.flipX = true;
    }
    void CreateArcher()
    {
        if (_game.myGold < Managers.Game.archerReqGold)
        {
            Debug.Log("궁수 출동 실패!");
            Managers.Sound.Play("Sound_Depurchase");
            return;
        }
        Debug.Log("궁수 출동!");
        Managers.Sound.Play("Sound_Purchase");
        _game.myGold -= Managers.Game.archerReqGold;
        GameObject go = Managers.Resource.Instantiate("Character/Enemy/EnemyArcher");
        //go.transform.position = new Vector3(-5.5f, -2.5f, 0);
        go.transform.position = spawnArea;
        go.AddComponent<ArcherStat>();
        go.AddComponent<ArcherController>();

        //// 상대도 똑같이 소환
        //GameObject enemyGo = Managers.Resource.Instantiate("Character/User/EnemyArcher");
        //enemyGo.transform.position = new Vector3(16.5f, -2.5f, 0);
        //enemyGo.AddComponent<ArcherStat>();
        //enemyGo.AddComponent<EnemyArcherController>();
        //SpriteRenderer sprite = enemyGo.GetOrAddComponent<SpriteRenderer>();
        //enemyGo.GetComponent<Collider2D>().offset = enemyGo.GetComponent<Collider2D>().offset * new Vector2(-1, 1);
        //sprite.flipX = true;
    }
    void CreateAssassin()
    {
        if (_game.myGold < Managers.Game.assassinReqGold)
        {
            Debug.Log("암살자 출동 실패!");
            Managers.Sound.Play("Sound_Depurchase");
            return;
        }
        Debug.Log("암살자 출동!");
        Managers.Sound.Play("Sound_Purchase");
        _game.myGold -= Managers.Game.assassinReqGold;
        GameObject go = Managers.Resource.Instantiate("Character/Enemy/EnemyAssassin");
        //go.transform.position = new Vector3(-5.5f, -2.5f, 0);
        go.transform.position = spawnArea;
        go.AddComponent<AssassinStat>();
        go.AddComponent<AssassinController>();

        // 상대도 똑같이 소환
        //GameObject enemyGo = Managers.Resource.Instantiate("Character/User/EnemyAssassin");
        //enemyGo.transform.position = new Vector3(16.5f, -2.5f, 0);
        //enemyGo.AddComponent<AssassinStat>();
        //enemyGo.AddComponent<EnemyAssassinController>();
        //SpriteRenderer sprite = enemyGo.GetOrAddComponent<SpriteRenderer>();
        //enemyGo.GetComponent<Collider2D>().offset = enemyGo.GetComponent<Collider2D>().offset * new Vector2(-1, 1);
        //sprite.flipX = true;
    }

    public void RefreshUI()
    {
        if (_init == false)
            return;

        RefreshMyHpBar();
        RefreshEnemyHpBar();
        RefreshGold();
    }
    public void RefreshMyHpBar()
    {
        float hpPercent = _game.MyHpPercent;
        int hp = _game.MyHp;
        int maxhp = _game.MyMaxHp;
        GetImage((int)Images.MyHpBarFill).fillAmount = hpPercent / 100.0f;
        GetText((int)Texts.MyHpBarText).text = $"My HP : {hp}/{maxhp}";

    }
    public void RefreshEnemyHpBar()
    {
        float hpPercent = _game.EnemyHpPercent;
        int hp = _game.EnemyHp;
        int maxhp = _game.EnemyMaxHp;
        GetImage((int)Images.EnemyHpBarFill).fillAmount = hpPercent / 100.0f;
        GetText((int)Texts.EnemyHpBarText).text = $"Enemy HP : {hp}/{maxhp}";

    }
    public void RefreshGold()
    {
        int gold = _game.myGold;
        GetText((int)Texts.GoldText).text = String.Format("{0:#,###}", gold);
    }

    GameObject HealCoolTimeCover;

    public void Skill1() // Healing
    {
        // 모든 아군의 체력을 unitHeal 만큼 회복시키고,
        // 업그레이드 레벨이 unitOnly을 넘기면 그때부턴 성의 체력도 회복시킨다
        if (HealCoolTimeCover != null)
            return;
        HealCoolTimeCover = Managers.Resource.Instantiate("UI/SkillCoolTime");
        HealCoolTimeCover.transform.SetParent(GetButton((int)Buttons.Skill1Btn).transform, false);
        Managers.Sound.Play("Sound_Heal");
        _game = Managers.Game;
        if(!_game.UnitOnly)
        {
            _game.MyHp += _game.CastleHeal;
            Managers.Resource.Instantiate("Game/HealingEffect4Castle");
        }
        GameObject[] MyUnits = GameObject.FindGameObjectsWithTag("Our");
        if (MyUnits.Length <= 0)
            return;
        foreach (GameObject unit in MyUnits)
        {
            Stat stat = unit.GetComponent<Stat>();
            SpriteRenderer sr = unit.GetComponent<SpriteRenderer>();
            stat.Hp += _game.Unitheal;
            GameObject healeffect = Managers.Resource.Instantiate("Game/HealingEffect4Unit");
            healeffect.transform.SetParent(unit.transform, false);
            sr.color = new Color(0.742f, 1.0f, 0.617f, 1.0f);
        }
        StartCoroutine("returnColor", MyUnits);
    }

    IEnumerator returnColor(GameObject[] MyUnits)
    {
        yield return new WaitForSeconds(1);
        foreach (GameObject unit in MyUnits)
        {
            if (unit == null)
                continue;
            SpriteRenderer sr = unit.GetComponent<SpriteRenderer>();
            sr.color = Color.white;
        }
    }

    GameObject MeteorCoolTimeCover;

    public void Skill2() // Meteor Shower
    {
        if (MeteorCoolTimeCover != null)
            return;
        MeteorCoolTimeCover = Managers.Resource.Instantiate("UI/SkillCoolTime");
        MeteorCoolTimeCover.transform.SetParent(GetButton((int)Buttons.Skill2Btn).transform, false);

        Managers.Resource.Instantiate("Game/MeteorEffect");
        // 사운드 추가
        Managers.Sound.Play("Sound_Meteor");
        GameObject[] MyUnits = GameObject.FindGameObjectsWithTag("Our");
        GameObject[] EnemyUnits = GameObject.FindGameObjectsWithTag("Enemy");
        if(_game.KillAll)
            StartCoroutine("SwipeUnits", MyUnits);
        StartCoroutine("SwipeUnits", EnemyUnits);

    }

    IEnumerator SwipeUnits(GameObject[] Units)
    {
        _game = Managers.Game;
        yield return new WaitForSeconds(0.8f);
        foreach (GameObject unit in Units)
        {
            if (unit == null)
                continue;
            unit.GetComponent<Stat>().Hp -= _game.Damage;
        }
    }

    GameObject BuffCoolTimeCover;

    float accelSpeed = 2;     // 두배속일때,
    float[] originAttackSpeed;
    float duration;         // 지속시간은 BuffData.xml을 참조
    public void Skill3() // Buff
    {
        if (BuffCoolTimeCover != null)
            return;
        Managers.Sound.Play("Sound_Giant");
        BuffCoolTimeCover = Managers.Resource.Instantiate("UI/SkillCoolTime");
        BuffCoolTimeCover.transform.SetParent(GetButton((int)Buttons.Skill3Btn).transform, false);

        int count = 0;
        GameObject[] MyUnits = GameObject.FindGameObjectsWithTag("Our");
        originAttackSpeed = new float[MyUnits.Length];
        foreach (GameObject unit in MyUnits)
        {
            SpriteRenderer sr = unit.GetComponent<SpriteRenderer>();
            originAttackSpeed[count++] = unit.GetComponent<Stat>().AttackSpeed;
            unit.GetComponent<Stat>().AttackSpeed /= accelSpeed;     // Stat의 Speed는 2로 나누어야하고,
            unit.GetComponent<Animator>().speed = accelSpeed;        // Animator의 Speed는 두배속
            unit.GetComponent<CreatureController>().Init();
            GameObject buffeffect = Managers.Resource.Instantiate("Game/BuffEffect");
            buffeffect.transform.SetParent(unit.transform, false);
            sr.color = Color.red;
        }
        StartCoroutine("buffEnd", MyUnits);
    }

    IEnumerator buffEnd(GameObject[] MyUnits)
    {
        duration = Managers.Game.Duration;
        yield return new WaitForSeconds(duration);
        int count = 0;
        foreach (GameObject unit in MyUnits)
        {
            if (!unit) continue;
            SpriteRenderer sr = unit.GetComponent<SpriteRenderer>();
            unit.GetComponent<Stat>().AttackSpeed = originAttackSpeed[count++];
            unit.GetComponent<Animator>().speed = 1;
            unit.GetComponent<CreatureController>().Init();
            sr.color = Color.white;
        }
    }

    public void myGoldIncome(int gold)
    {
        if (playTime >= (OurPrevIncomeTime + goldIncomeInterval))   // 일정시간마다 주기적으로 골드가 늘어난다
        {
            OurPrevIncomeTime = playTime;
            Debug.Log("골드 수급!");
            _game.myGold += gold;
        }
    }

    public void enemyGoldIncome(int gold)
    {
        if (playTime >= (EnemyPrevIncomeTime + goldIncomeInterval))   // 일정시간마다 주기적으로 골드가 늘어난다
        {
            EnemyPrevIncomeTime = playTime;
            Debug.Log("Enemy 골드 수급!");
            _game.enemyGold += gold;
        }
    }

    public void myGoldIncomeSet(int num)
    {
        MyGoldIncome = num;
    }

    public void enemyGoldIncomeSet(int num)
    {
        EnemyGoldIncome = num;
    }

    // set game difficulty to click the button
    protected void StartGame()
    {
        switch (Managers.Game.difficulty)
        {
            case (int)Define.Difficulty.Easy:
                EasyGame();
                break;
            case (int)Define.Difficulty.Normal:
                NormalGame();
                break;
            case (int)Define.Difficulty.Hard:
                HardGame();
                break;
        }
    }

    private void EasyGame()
    {
        spawnInterval = 2.0f;
        Debug.Log("EASY");
        myGoldIncomeSet(100);
        enemyGoldIncomeSet(200);
        if (playTime >= (prevSpawnTime + spawnInterval))  
        {
            prevSpawnTime = playTime;
            RandomSpawn();
        }
    }

    private void NormalGame()
    {
        spawnInterval = 1.7f;
        Debug.Log("NORMAL");
        myGoldIncomeSet(90);
        enemyGoldIncomeSet(250);
        if (playTime >= (prevSpawnTime + spawnInterval))
        {
            prevSpawnTime = playTime;
            RandomSpawn();
        }
    }

    private void HardGame()
    {
        spawnInterval = 1.5f;
        Debug.Log("HARD");
        myGoldIncomeSet(80);
        enemyGoldIncomeSet(300);
        if (playTime >= (prevSpawnTime + spawnInterval))
        {
            prevSpawnTime = playTime;
            RandomSpawn();
        }
    }

    private void RandomSpawn()
    {
        System.Random rand = new System.Random();
        int enemy = rand.Next(0, 3);
        if (enemy == 0)
        {
            if (_game.enemyGold < Managers.Game.knightReqGold)
                return;
            _game.enemyGold -= Managers.Game.knightReqGold;
            GameObject enemyGo = Managers.Resource.Instantiate("Character/User/EnemyKnight");
            enemyGo.transform.position = new Vector3(16.5f, -2.5f, 0);
            enemyGo.AddComponent<KnightStat>();
            enemyGo.AddComponent<EnemyKnightController>();
            SpriteRenderer sprite = enemyGo.GetOrAddComponent<SpriteRenderer>();
            enemyGo.GetComponent<Collider2D>().offset = enemyGo.GetComponent<Collider2D>().offset * new Vector2(-1, 1);
            sprite.flipX = true;
        }
        else if (enemy == 1)
        {
            if (_game.enemyGold < Managers.Game.archerReqGold)
                return;
            _game.enemyGold -= Managers.Game.archerReqGold;
            GameObject enemyGo = Managers.Resource.Instantiate("Character/User/EnemyArcher");
            enemyGo.transform.position = new Vector3(16.5f, -2.5f, 0);
            enemyGo.AddComponent<ArcherStat>();
            enemyGo.AddComponent<EnemyArcherController>();
            SpriteRenderer sprite = enemyGo.GetOrAddComponent<SpriteRenderer>();
            enemyGo.GetComponent<Collider2D>().offset = enemyGo.GetComponent<Collider2D>().offset * new Vector2(-1, 1);
            sprite.flipX = true;
        }
        else
        {
            if (_game.enemyGold < Managers.Game.assassinReqGold)
                return;
            _game.enemyGold -= Managers.Game.assassinReqGold;
            GameObject enemyGo = Managers.Resource.Instantiate("Character/User/EnemyAssassin");
            enemyGo.transform.position = new Vector3(16.5f, -2.5f, 0);
            enemyGo.AddComponent<AssassinStat>();
            enemyGo.AddComponent<EnemyAssassinController>();
            SpriteRenderer sprite = enemyGo.GetOrAddComponent<SpriteRenderer>();
            enemyGo.GetComponent<Collider2D>().offset = enemyGo.GetComponent<Collider2D>().offset * new Vector2(-1, 1);
            sprite.flipX = true;
        }

    }
}