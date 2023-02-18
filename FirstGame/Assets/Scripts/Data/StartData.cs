using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class StartData
{
    [XmlAttribute]
    public int myMaxHp;
    [XmlAttribute]
    public int enemyMaxHp;
    [XmlAttribute]
    public int myGold;
    [XmlAttribute]
    public int enemyGold;
    [XmlAttribute]
    public int difficulty;
}