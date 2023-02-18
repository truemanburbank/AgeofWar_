using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcherController : CreatureController
{
    ArcherStat _ArcherStat;
    float attackSpeed;
    float _attDistance;
    Vector3 editRayPosition = new Vector3(0, 0.5f, 0);

    public void Start()
    {
        Init();
    }

    public override void Init()
    {
        _ArcherStat = gameObject.GetComponent<ArcherStat>();
        walkingDir = (gameObject.tag == "Our") ? Vector3.right : Vector3.left;
        State = Define.State.Walk;
        attackSpeed = _ArcherStat.AttackSpeed;
        _attDistance = _ArcherStat.Range;
        _myMat = gameObject.GetComponent<SpriteRenderer>().material;
        _myOriginal = _myMat.shader;
    }

    protected override void Walking()
    {
        transform.position += walkingDir * _ArcherStat.MoveSpeed * Time.deltaTime;
        Debug.DrawRay(gameObject.transform.position - editRayPosition, Vector3.left * _attDistance, Color.green);
        // start dir distance layer
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position - editRayPosition, Vector3.left, _attDistance, LayerMask.GetMask("Our") | LayerMask.GetMask("Castle"));
        if (hit.collider != null && hit.collider.gameObject.layer == (int)Define.Layer.Our)
        {
            _enemyMat = hit.collider.GetComponent<SpriteRenderer>().material;

            State = Define.State.AttackA;
            _collision = hit.collider;
            _enemyOriginal = _enemyMat.shader;
        }
        else if (hit.collider != null && hit.collider.gameObject.layer == (int)Define.Layer.Castle)
        {
            State = Define.State.AttackB;
        }
    }

    protected override void Idle() { }
    protected override void AttackA(Collider2D collision)
    {

        Animator anim = gameObject.GetComponent<Animator>();
        if (playTime < prevAttackTime + attackSpeed)
            return;
        if (collision != null)
        {
            prevAttackTime = playTime;
            Stat opp = collision.gameObject.GetComponent<Stat>();
            anim.Play("ATTACKA");
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("ATTACKA") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                Managers.Sound.Play("Sound_Archer_AttackA");
                opp.Hp -= Math.Max(_ArcherStat.Attack - opp.Defence, 0);
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
        Debug.Log($"Our Castle이 {_ArcherStat.Attack}의 피해를 받음!");
        Managers.Sound.Play("Sound_Archer_AttackB");
        Managers.Game.MyHp = Math.Max(0, Managers.Game.MyHp - _ArcherStat.Attack);

        if (Managers.Game.MyHp <= 0 || Managers.Game.EnemyHp <= 0)
        {
            State = Define.State.Idle;
        }
    }

    protected override void Dead()
    {
        if (_enemyOriginal != null)
            _enemyMat.shader = _enemyOriginal;
        getGold(_ArcherStat.DropGold);

        Destroy(gameObject.GetComponent<Collider2D>());
        Destroy(gameObject, 1.0f);
    }
}