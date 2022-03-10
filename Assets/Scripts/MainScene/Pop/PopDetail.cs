using System.Collections;
using System.Collections.Generic;
using Tais.API;
using UnityEngine;
using UnityEngine.UI;

class PopDetail : RxMonoBehaviour
{
    public Text liveliHood;

    public IPop pop;

    // Start is called before the first frame update
    void Start()
    {
        dataBind.BindText(pop.liveliHood, x => x.value, liveliHood);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
