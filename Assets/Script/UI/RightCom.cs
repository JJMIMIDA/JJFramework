using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCom : CompUI
{
    public RightCom(GameObject _parentRoot) : base(_parentRoot)
    {
       
    }

    public override void OnInit()
    {

        Debug.Log("RightCom OnInit######");
    }

    public override void OnShow()
    {
        Debug.Log("RightCom OnShow######");
    }

    protected override string srcPath()
    {
        return "Prefab/RightCom";
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Debug.Log("RightCom Destroy############");
    }

}
