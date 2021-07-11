using System;
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

    Dictionary<Type, EntityUI> openDic = new Dictionary<Type, EntityUI>();
    


    #region UI层级
    //一般地，我们Open一个EntityUI的时候，该EntityUI都会盖在最上层，
    //因此，我们把新打开的UI放到更前面的层次
    int currentLayerIndex =0;

    /// <summary>
    /// UI层级的偏移
    /// </summary>
    const  int layerZOffset = 1000;

    const string layerPrefabPath = "Prefab/UIFrame/UILayer";

    const string cavansPrefabPath = "Prefab/UIFrame/UICanvas";
    #endregion

    /// <summary>
    /// 打开一个UI,通过泛型解决switch case烦恼
    /// case: UIManager.Instance.OpenUI<MainUI>();
    /// case: UIManager.Instance.OpenUI<PopUI>();
    /// </summary>
    public void OpenUI<UI>() where UI : EntityUI, new()
    {
        //检查该UI是否已存在，如果是调用OnShow并返回
        if (openDic.TryGetValue(typeof(UI), out EntityUI baseUI))
        {
            baseUI.OnShow();
            return;
        }
        else
        {
            GameObject layerRoot = UILoader.Instance.LoadSyncUI(layerPrefabPath);
            layerRoot.transform.SetParent(UIRoot.transform,false);
            //相机反向，z走负数
            layerRoot.transform.localPosition = new Vector3(0,0, -layerZOffset* currentLayerIndex);
            layerRoot.name = "layerRoot" + currentLayerIndex++;
            baseUI = new UI();
            EntityUICanvasType mtype =  baseUI.CanvasType();
            GameObject uiParentRoot=null;
            //位操作
            if ((mtype & EntityUICanvasType.bg) != EntityUICanvasType.NULL)
            {
                //创建Bg层
                GameObject bgCanvas = UILoader.Instance.LoadSyncUI(cavansPrefabPath);
                bgCanvas.name = "bgCanvas";
                bgCanvas.transform.SetParent(layerRoot.transform,false);
                bgCanvas.transform.localPosition = new Vector3(0, 0, -200);
                uiParentRoot = bgCanvas; 
            }

            if ((mtype & EntityUICanvasType.center) != EntityUICanvasType.NULL)
            {
                //创建Center层
                GameObject centerCanvas = UILoader.Instance.LoadSyncUI(cavansPrefabPath);
                centerCanvas.name = "centerCanvas";
                centerCanvas.transform.SetParent(layerRoot.transform, false);
                centerCanvas.transform.localPosition = new Vector3(0, 0, -400);
                uiParentRoot = centerCanvas;
            }

            if ((mtype & EntityUICanvasType.top) != EntityUICanvasType.NULL)
            {
                //创建Top层
                GameObject topCanvas = UILoader.Instance.LoadSyncUI(cavansPrefabPath);
                topCanvas.name = "topCanvas";
                topCanvas.transform.SetParent(layerRoot.transform, false);
                topCanvas.transform.localPosition = new Vector3(0, 0, -600);
                uiParentRoot = topCanvas;
            }
            
            //如果三层都没配置，直接抛异常
            if(uiParentRoot==null)
            {
                throw new Exception("please return not NULL type in EntityUI.CanvasType()");
            }
            GameObject root = baseUI.Init(UILoader.Instance, uiParentRoot);
            if (root != null)
            {
                baseUI.OnInit();
            }
            baseUI.OnShow();
            openDic.Add(typeof(UI), baseUI);
        }
    }

    /// <summary>
    /// 关闭一个UI
    /// </summary>
    public  void CloseUI<UI>() where UI : EntityUI, new()
    {
        if(openDic.TryGetValue(typeof(UI),out EntityUI baseUI))
        {
            if(baseUI!=null)
            {
                baseUI.OnDestroy();
            }
            openDic.Remove(typeof(UI));
        }
    }


}
