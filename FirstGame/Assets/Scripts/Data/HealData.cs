using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class HealData
{
    [XmlAttribute]
    public int unitHeal;
    [XmlAttribute]
    public int specialHealLvl;
    [XmlAttribute]
    public bool unitOnly;
    [XmlAttribute]
    public int castleHeal;
}