using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompUI : BaseUI
{

    public CompUI(GameObject _parentRoot)
    {
        Init(UILoader.Instance, _parentRoot);
        OnInit();
        OnShow();
    }

    public override void OnInit()
    {
       
    }

    protected override string srcPath()
    {
        return "";
    }


}
