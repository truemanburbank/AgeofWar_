using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAssassinController : CreatureController
{
    AssassinStat _AssassinStat;
    float attackSpeed;
    float _attDistance;

    Vector3 editRayPosition = new Vector3(0, 0.5f, 0);

    public void Start()
    {
        Init();
    }

    public override void Init()
    {
        _AssassinStat = gameObject.GetComponent<AssassinStat>();
        walkingDir = (gameObject.tag == "Our") ? Vector3.right : Vector3.left;
        State = Define.State.Walk;
        attackSpeed = _AssassinStat.AttackSpeed;
        _attDistance = _AssassinStat.Range;
        _myMat = gameObject.GetComponent<SpriteRenderer>().material;
        _myOriginal = _myMat.shader;
    }

    protected override void Walking()
    {
        transform.position += walkingDir * _AssassinStat.MoveSpeed * Time.deltaTime;
        Debug.DrawRay(gameObject.transform.position - editRayPosition, Vector3.left * _attDistance, Color.green);
        // start dir distance layer
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position - editRayPosition, Vector3.left, _attDistance, LayerMask.GetMask("Our") | LayerMask.GetMask("Castle"));
        if (hit.collider != null && hit.collider.gameObject.layer == (int)Define.Layer.Our)
        {
            _enemyMat = hit.collider.GetComponent<SpriteRenderer>().material;
            _enemyOriginal = _enemyMat.shader;           
            _collision = hit.collider;
            State = Define.State.AttackA;
        }
        else if (hit.collider != null && hit.collider.gameObject.layer == (int)Define.Layer.Castle)
        {
            State = Define.State.AttackB;
        }
    }

    protected override void Idle() { }
    protected override void AttackA(Collider2D collision)
    {
        if (playTime < prevAttackTime + attackSpeed)
            return;
        if (collision != null)
        {
            prevAttackTime = playTime;
            Animator anim = gameObject.GetComponent<Animator>();
            Stat opp = collision.gameObject.GetComponent<Stat>();
            anim.Play("ATTACKA");
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("ATTACKA") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                Managers.Sound.Play("Sound_AttackA");
                opp.Hp -= Math.Max(_AssassinStat.Attack - opp.Defence, 0);
                ExecuteFlash();
            }
        }
        else State = Define.State.Walk;
    }

    protected override void AttackB() 
    {
        // AttackB의 상태로 포탑 공격
        if (playTime < prevAttackTime + attackSpeed)
            return;
        prevAttackTime = playTime;

        Animator anim = gameObject.GetComponent<Animator>();
        anim.Play("ATTACKA");
        Managers.Sound.Play("Sound_AttackB");
        Debug.Log($"Our Castle이 {_AssassinStat.Attack}의 피해를 받음!");
        Managers.Game.MyHp = Math.Max(0, Managers.Game.MyHp - _AssassinStat.Attack);

        if (Managers.Game.MyHp <= 0 || Managers.Game.EnemyHp <= 0)
        {
            State = Define.State.Idle;
        }
    }

    protected override void Dead()
    {
        if (_enemyOriginal != null)
            _enemyMat.shader = _enemyOriginal;
        getGold(_AssassinStat.DropGold);

        Destroy(gameObject.GetComponent<Collider2D>());
        Destroy(gameObject, 1.0f);
    }
}
