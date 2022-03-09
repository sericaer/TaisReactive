using System.Collections;
using Tais.API;
using UnityEngine;
using UnityEngine.UI;

class PopItem : RxMonoBehaviour
{
    public Text popName;
    public Text popCount;

    public IPop pop;

    // Use this for initialization
    void Start()
    {
        popName.text = pop.name;

        dataBind.BindText(pop, x => x.num, popCount);
    }

    // Update is called once per frame
    void Update()
    {

    }
}