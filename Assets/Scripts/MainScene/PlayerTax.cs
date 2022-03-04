using System;
using System.Collections;
using System.Collections.Generic;
using Tais.GSessions;
using UnityEngine;
using UnityEngine.UI;

class PlayerTax : RxMonoBehaviour
{
    public Text stock;
    public Text perMonth;

    // Start is called before the first frame update
    void Start()
    {
        dataBind.BindText(GSession.inst.taxMgr, x => x.stock, stock);
        dataBind.BindText(GSession.inst.taxMgr, x => x.taxPerMonth, perMonth, (v)=> $"(" + v.ToString("+0;-#") +")");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
