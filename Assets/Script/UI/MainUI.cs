using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : EntityUI
{

    public MainUI():base()
    {

    }

    /// <summary>
    /// 一个gameobject 的root节点绑定一个baseUI
    /// </summary>
    /// <returns></returns>
    protected override string srcPath()
    {
        return "Prefab/Entity/MainUI";
    }

    /// <summary>
    /// 初始化节点
    /// </summary>
    public override void OnInit()
    {
        

        Debug.Log("MainUI OnInit");

        //主界面左边的功能模块

        //主界面上边的功能模块

        //主界面下边的功能模块

        //主界面右边的功能模块
        //TODO: RightCom的封装
        this.AddUI(new RightCom(root.transform.Find("Right").gameObject));

    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Debug.Log("MainUI Destroy############");
    }

    public override EntityUICanvasType CanvasType()
    {
        //比如MainUI需要一个三层canvas:
        return EntityUICanvasType.bg | EntityUICanvasType.center | EntityUICanvasType.top;
    }
}
