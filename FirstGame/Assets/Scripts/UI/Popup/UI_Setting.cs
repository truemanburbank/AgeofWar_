using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UI_Setting : UI_Popup
{
    AudioSource CurrentBGM = Managers.Sound.GetCurrent();
    private float Vol = 1f;
    public Slider Sound;

    static int count = 0;

    enum Buttons
    {
        Back,
        Exit,
    }

    enum Texts
    {
        BackText,
        ExitText,
        SoundText,
    }

    private void Start()
    {
        Init();
        SoundInit();
    }

    private void Update()
    {
        SoundControl();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        //Managers.UI.SetCanvas(gameObject, true);      

        BindButton(typeof(Buttons));
        BindText(typeof(Texts));

        GetButton((int)Buttons.Back).gameObject.BindEvent(Back);
        GetButton((int)Buttons.Exit).gameObject.BindEvent(Exit);

        return true;
    }

    void SoundInit()
    {
        if (count == 0)
        {
            Vol = PlayerPrefs.GetFloat("Vol", 1f);
            Sound.value = Vol;
            CurrentBGM.volume = Sound.value;
            count++;
        }
        else
        {
            Vol = PlayerPrefs.GetFloat("Sound", Vol);
            Sound.value = Vol;
            CurrentBGM.volume = Sound.value;
        }
        
    }

    void SoundControl()
    {
        CurrentBGM.volume = Sound.value;
        Vol = Sound.value;
        PlayerPrefs.SetFloat("Sound", Vol);
    }

    public override void ClosePopupUI()
    {
        Managers.UI.ClosePopupUI(this);
    }


    void Back()
    {
        Debug.Log("�ڷ� ����");
        IsPause = true;
        PauseChecker();
        ClosePopupUI();
    }
    void Exit()
    {
        Debug.Log("������");
        Application.Quit();
    }
}

