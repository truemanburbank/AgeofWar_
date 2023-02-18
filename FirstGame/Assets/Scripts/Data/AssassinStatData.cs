using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class AssassinStatData
{
    [XmlAttribute]
    public int maxHp;
    [XmlAttribute]
    public int attack;
    [XmlAttribute]
    public float attackSpeed;
    [XmlAttribute]
    public int defence;
    [XmlAttribute]
    public float moveSpeed;
    [XmlAttribute]
    public int reqGold;
    [XmlAttribute]
    public int dropGold;
    [XmlAttribute]
    public float range;
}