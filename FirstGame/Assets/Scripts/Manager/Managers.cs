using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers s_instance = null;
    public static Managers Instance { get { return s_instance; } }

    public static GameManager s_gameManager = new GameManager();
    public static ResourceManager s_resource = new ResourceManager();
    public static SceneManager s_scene = new SceneManager();
    public static SoundManager s_sound = new SoundManager();
    public static UIManager s_ui = new UIManager();
    public static DataManager s_dataManager = new DataManager();

    public static GameManager Game { get { Init(); return s_gameManager; } }
    public static ResourceManager Resource { get { Init(); return s_resource; } }
    public static SceneManager Scene { get { Init(); return s_scene; } }
    public static SoundManager Sound { get { return s_sound; } }
    public static UIManager UI { get { Init(); return s_ui; } }
    public static DataManager Data { get { Init(); return s_dataManager; } }


    private void Start()
    {
        Init();
    }

    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
                go = new GameObject { name = "@Managers" };

            s_instance = Utils.GetOrAddComponent<Managers>(go);
            DontDestroyOnLoad(go);

            s_instance = go.GetComponent<Managers>();
            s_sound.Init();
            s_dataManager.Init();
            s_gameManager.Init();
        }
    }

    static void Clear()
    {
        Sound.Clear();
        UI.Clear();
    }
}