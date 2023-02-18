using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldDropVFXController : MonoBehaviour
{
    int gold;

    void Start()
    {
        gold = transform.parent.gameObject.GetComponent<Stat>().DropGold;
        GetComponentInChildren<TextMeshPro>().text = $"+{gold}";

        Destroy(gameObject, 0.7f);
    }

}
