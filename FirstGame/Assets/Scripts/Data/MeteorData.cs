using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MeteorData
{
    [XmlAttribute]
    public int damage;
    [XmlAttribute]
    public int specialMeteorLvl;
    [XmlAttribute]
    public bool killAll;
}