using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tais.GSessions;
using UnityEngine;
using UnityEngine.UI;

class TopTax : RxMonoBehaviour
{
    public Text stock;
    public Text perMonth;
    public LazyUpdateTooltipTrigger tooltipTrigger;

    // Start is called before the first frame update
    void Start()
    {
        dataBind.BindText(GSession.inst.taxMgr, x => x.stock, stock);
        dataBind.BindText(GSession.inst.taxMgr, x => x.taxPerMonth, perMonth, (v)=> "(" + v.ToString("+0;-#") +")");
        tooltipTrigger.funcGenerateTextInfo = () =>
        {
            var info = string.Join("\n", GSession.inst.taxMgr.taxSourcesPerMonth.Items.Select(x => x.label + " " + x.value.ToString("+0;-#")));
            return new (string, string)[] { ("BodyText", info) };
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
