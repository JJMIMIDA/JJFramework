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
        Transform room1 = root.gameObject.transform.Find("Room_1");
        //room1.transform.Find("Button_1 Gray").GetComponent<>;
        Debug.Log("RightCom OnInit######");
    }

    public override void OnShow()
    {
        Debug.Log("RightCom OnShow######");
    }

    protected override string srcPath()
    {
        return "Prefab/Entity/RightCom";
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Debug.Log("RightCom Destroy############");
    }

}
