using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUI : EntityUI
{
    public PopUI() : base()
    {

    }

    public override EntityUICanvasType CanvasType()
    {
        return EntityUICanvasType.top;
    }

    public override void OnInit()
    {
        Debug.Log("PopUI Init");
    }

    protected override string srcPath()
    {
        return "Prefab/Entity/PopUI";
    }
}
