using System.Collections;
using System.Collections.Generic;
using Tais.GSessions;
using UnityEngine;
using UnityEngine.UI;

class TopPop : RxMonoBehaviour
{
    public Text popCount;

    // Start is called before the first frame update
    void Start()
    {
        dataBind.BindText(GSession.inst.popMgr, x => x.totalCount, popCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
