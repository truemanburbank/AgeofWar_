using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkilCoolTimeController : MonoBehaviour
{
    float time = 3.0f;
    float cooltime = 3.0f;
    Image image;
    TextMeshProUGUI text;
    void Start()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        image.fillAmount = 1;
    }
    
    void FixedUpdate()
    {
        time -= Time.deltaTime;
        image.fillAmount = time / cooltime;
        text.text = String.Format("{0:0}", time); 
        if (time <= 0)
            Destroy(gameObject);
    }
}
