using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField]
    protected int _hp;
    [SerializeField]
    protected int _maxHp;
    [SerializeField]
    protected int _attack;
    [SerializeField]
    protected float _attackSpeed;
    [SerializeField]
    protected int _defence;
    [SerializeField]
    protected float _moveSpeed;
    [SerializeField]
    protected int _reqGold;
    [SerializeField]
    protected int _dropGold;
    [SerializeField]
    protected float _range;

    public int Hp { get { return _hp; } set { _hp = value; } }
    public int MaxHp { get { return _maxHp; } set { _maxHp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    public int Defence { get { return _defence; } set { _defence = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public int ReqGold { get { return _reqGold; } set { _reqGold = value; } }
    public int DropGold { get { return _dropGold; } set { _dropGold = value; } }
    public float Range { get { return _range; } set { _range = value; } }
}
