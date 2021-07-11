using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.OpenUI<MainUI>();
        //UIManager.Instance.OpenUI<PopUI>();
        UIManager.Instance.CloseUI<MainUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
