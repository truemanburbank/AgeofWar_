using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class UpgradeData
{
    [XmlAttribute]
    public int knightUpgradeLvl;
    [XmlAttribute]
    public int assassinUpgradeLvl;
    [XmlAttribute]
    public int archerUpgradeLvl;
    [XmlAttribute]
    public int healUpgradeLvl;
    [XmlAttribute]
    public int meteorUpgradeLvl;
    [XmlAttribute]
    public int buffUpgradeLvl;
}