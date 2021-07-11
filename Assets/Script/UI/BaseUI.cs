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

    List<BaseUI> mbaseUIs = new List<BaseUI>();

    /// <summary>
    /// UI资源的加载器
    /// </summary>
    IUILoader loader;


    /// <summary>
    /// TODO：垃圾定义，每次挪文件夹都需要修改
    /// </summary>
    /// <returns></returns>
    protected abstract string srcPath();

    public BaseUI()
    {
      
    }

    public BaseUI(IUILoader _loader, GameObject _parentRoot)
    {
        Init(_loader, _parentRoot);
    }

    public GameObject Init(IUILoader _loader, GameObject _parentRoot)
    {
        this.parentRoot = _parentRoot;
        loader = _loader;
        this.root = loader.LoadSyncUI(this.srcPath()); //Resource.Load();
        root.transform.SetParent(_parentRoot.transform, false);
        return this.root;
    }

    protected void AddUI(BaseUI baseui)
    {

        mbaseUIs.Add(baseui);

    }


    /// <summary>
    /// UI节点初始化完成
    /// </summary>
    /// <param name="srcPath"></param>
    public abstract void OnInit();
  

    public virtual void OnShow()
    {

    }

    public virtual void OnHide()
    {

    }

    public virtual void OnDestroy()
    {
        if(root!=null)
        {
            GameObject.DestroyImmediate(root);
            root = null;
        }
        for(int index =0; index < mbaseUIs.Count;index++)
        {
            BaseUI baseUI = mbaseUIs[index];
            baseUI.OnDestroy();
        }
    }
}

public interface IUILoader
{
    GameObject LoadSyncUI(string path);



    /// LoadAysnUI(string path,);
}




