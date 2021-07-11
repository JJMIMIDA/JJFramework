using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUI : BaseUI
{
    public PopUI() : base()
    {

    }

    public override void OnInit()
    {
        Debug.Log("PopUI Init");
    }

    protected override string srcPath()
    {
        return "Prefab/PopUI";
    }
}
