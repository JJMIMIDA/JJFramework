using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// entityUI 作为一个大的UI实体，UIManager.OpenUI的实体对象
/// </summary>
public abstract class EntityUI : BaseUI
{
    #region EntityUI分三层的好处：canvas动静分离，显示层级可控
    /// <summary>
    /// 该节点用来放置背景底图
    /// </summary>
    protected Canvas bgRoot;

    /// <summary>
    /// 该节点用来放置3D模型
    /// </summary>
    protected Canvas centerRoot;

    /// <summary>
    /// 该节点用来放置UI
    /// </summary>
    protected Canvas topRoot;
    #endregion

    public override void OnInit()
    {
       
    }

    protected override string srcPath()
    {
        return "";
    }

    public abstract  EntityUICanvasType CanvasType();
   

}

//定义一个枚举类型，配置该entityUI需要的canvas层
public enum EntityUICanvasType
{
    NULL =0,
    bg = 1,
    center =2,
    top = 4
}
