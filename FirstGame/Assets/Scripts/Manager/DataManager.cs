using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public StartData Start { get; private set; }
    public KnightStatData KnightStat { get; private set; }
    public AssassinStatData AssassinStat { get; private set; }
    public ArcherStatData ArchorStat { get; private set; }
    public HealData HealStat { get; private set; }
    public MeteorData MeteorStat { get; private set; }
    public BuffData BuffStat { get; private set; }
    public UpgradeData UpgradeStat { get; private set; }

    public void Init()
    {
        Start = LoadSingleXml<StartData>("StartData");
        KnightStat = LoadSingleXml<KnightStatData>("KnightStatData");
        AssassinStat = LoadSingleXml<AssassinStatData>("AssassinStatData");
        ArchorStat = LoadSingleXml<ArcherStatData>("ArcherStatData");
        HealStat = LoadSingleXml<HealData>("HealData");
        MeteorStat = LoadSingleXml<MeteorData>("MeteorData");
        BuffStat = LoadSingleXml<BuffData>("BuffData");
        UpgradeStat = LoadSingleXml<UpgradeData>("UpgradeData");
    }

    private Item LoadSingleXml<Item>(string name)
    {
        XmlSerializer xs = new XmlSerializer(typeof(Item));
        TextAsset textAsset = Resources.Load<TextAsset>("Data/" + name);
        using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(textAsset.text)))
            return (Item)xs.Deserialize(stream);
    }
    //public Dictionary<int, Data.Stat> StatDict { get; protected set; } = new Dictionary<int, Data.Stat>();
    //public void Init()
    //{
    //    StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
    //}

    //Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    //{
    //    TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
    //    return JsonUtility.FromJson<Loader>(textAsset.text);
    //}
}

// ?????? ?????? ???????????????


#region TODO

// ?????? ????????? ????????? ??????

// ????????? ??????????????? ?????? ??? ?????? ???????????????

// ????????? ????????? ?????? ????????? ??? ?????? ??? ?????? ???????????????

// ????????? ??? ???????????????

// 
// 

#endregion