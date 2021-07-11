using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责管理UI实体
/// </summary>
public abstract class BaseUI
{
    /// <summary>
    /// ui根节点,在打开UI的时候，绑定root界面
    /// </summary>
    protected GameObject root;

    GameObject parentRoot;

    /// <summary>
    /// UI资源的加载器
    /// </summary>
    IUILoader loader;


    protected abstract string srcPath();

    public BaseUI()
    {
      
    }

    public GameObject Init(IUILoader _loader, GameObject _parentRoot)
    {
        this.parentRoot = _parentRoot;
        loader = _loader;
        this.root = loader.LoadSyncUI(this.srcPath()); //Resource.Load();
        return this.root;
    }

    protected void AddUI(BaseUI baseui)
    {

    }


    /// <summary>
    /// UI节点初始化完成
    /// </summary>
    /// <param name="srcPath"></param>
    public abstract void OnInit();
  

    public void OnShow()
    {

    }

    public void OnHide()
    {

    }

    public void OnDestroy()
    {

    }
}

public interface IUILoader
{
    GameObject LoadSyncUI(string path);



    /// LoadAysnUI(string path,);
}




