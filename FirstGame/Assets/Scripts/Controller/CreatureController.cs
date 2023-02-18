using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureController : MonoBehaviour
{
    [SerializeField]
    protected Define.State _state = Define.State.Idle;

    Stat stat;
    protected Vector3 walkingDir;
    protected float playTime = 0;
    protected float prevAttackTime = 0;
    protected Collider2D _collision;
    bool dead = false;
    bool _end = false;

    // hit
    private Coroutine co;
    protected Shader _flashShader;
    protected Coroutine flashRoutine;

    protected Material _enemyMat;
    protected Shader _enemyOriginal;

    protected Material _myMat;
    protected Shader _myOriginal;

    protected virtual Define.State State
    {
        get { return _state; }
        set { _state = value; }
    }

    public virtual void Update()
    {
        EndGame();
        playTime += Time.deltaTime;
        Animator anim = gameObject.GetComponent<Animator>();
        Stat stat= gameObject.GetComponent<Stat>();
;
        if (stat.Hp <= 0 && State != Define.State.Dead)
            State = Define.State.Dead;
        switch (State)
        {
            case Define.State.Dead:
                anim.Play("DEAD");
                Dead();
                break;
            case Define.State.Walk:
                anim.Play("WALK");
                Walking();
                break;
            case Define.State.Idle:
                anim.Play("IDLE");
                Idle();
                break;
            case Define.State.AttackA:
                AttackA(_collision);
                break;
            case Define.State.AttackB:
                anim.Play("ATTACKB");
                AttackB();
                break;
        }
    }

    private void Start()
    {
        Init();
    }

    public abstract void Init();
    protected virtual void Dead(){ }

    protected virtual void Walking() { }
    protected virtual void Idle() { }
    protected virtual void AttackA(Collider2D collision) {}
    protected virtual void AttackB() { }

    public void ExecuteFlash()
    {
        flashRoutine = StartCoroutine(nameof(FlashRoutine));
    }

    public IEnumerator FlashRoutine()
    {
        if (_flashShader == null)
        {
           _flashShader = Shader.Find("GUI/Text Shader");
        }
        if (_enemyMat.shader == _flashShader)
        {
            _enemyMat.shader = _enemyOriginal;
            _enemyMat.shader = _flashShader;
            yield return new WaitForSeconds(0.1f);
            _enemyMat.shader = _enemyOriginal;
        }
        else
        {
            _enemyOriginal = _enemyMat.shader;
            _enemyMat.shader = _flashShader;
            yield return new WaitForSeconds(0.1f);
            _enemyMat.shader = _enemyOriginal;
        }
    }

    protected virtual void enemyGetGold(int money)    // 우리 유닛이 죽을 때 호출 할 함수   
    {
        if (dead == false)
        {
            dead = true;
            Debug.Log($"유닛이 {money}골드 드랍!");
            Managers.Game.enemyGold += money;
        }
    }   
    
    protected virtual void getGold(int money)    // 적 유닛이 죽을 때 호출 할 함수
    {
        if (dead == false)
        {
            dead = true;
            Debug.Log($"상대 유닛이 {money}골드 드랍!");
            Managers.Game.myGold += money;
            GameObject vfx = Managers.Resource.Instantiate("Game/GoldDropVFX");
            vfx.transform.SetParent(gameObject.transform, false);
        }
    }

    void EndGame()
    {
        if (_end == false && Managers.Game.EnemyHp <= 0) { Managers.UI.ShowPopupUI<UI_Win>(); _end= true; }
        else if (_end == false && Managers.Game.MyHp <= 0) { Managers.UI.ShowPopupUI<UI_Lose>(); _end= true; }
    }
}