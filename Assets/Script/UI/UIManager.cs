using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI管理器，负责管理所有的UI
/// </summary>
public class UIManager
{

    public static GameObject UIRoot;

    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    UIManager ()
    {
        UIRoot = GameObject.Find("UIRoot");
    }


    /// <summary>
    /// 打开一个UI,通过泛型解决switch case烦恼
    /// case: UIManager.Instance.OpenUI<MainUI>();
    /// case: UIManager.Instance.OpenUI<PopUI>();
    /// </summary>
    public void OpenUI<UI>() where UI : BaseUI,new()
    {

        UI baseUI = new UI();
        GameObject root = baseUI.Init(UILoader.Instance, UIRoot);
        root.transform.SetParent(UIRoot.transform,false);
        if (root!=null)
        {
            baseUI.OnInit();
        }
        baseUI.OnShow();

        /// new MainUI() || new PopUI() || new xxxUI()

    }

    /// <summary>
    /// 关闭一个UI
    /// </summary>
    public  void CloseUI()
    {

    }


}
