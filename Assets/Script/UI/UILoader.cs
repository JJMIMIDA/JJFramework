using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoader : IUILoader
{
    private static UILoader _instance;

    public static UILoader Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UILoader();
            }
            return _instance;
        }
    }

    /// <summary>
    /// 同步加载UI
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public GameObject LoadSyncUI(string path)
    {
        GameObject a=null;
        GameObject loadObj = Resources.Load(path) as GameObject;
        a= GameObject.Instantiate(loadObj);
        return a;
    }




}
