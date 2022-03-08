using System.Collections;
using Tais.API;
using UnityEngine;
using UnityEngine.UI;

class TabDepartBaseInfo : RxMonoBehaviour
{
    public Text popCount;
    public Toggle[] taxLevelToggle;

    public IDepart depart { get; set; }

    // Use this for initialization
    void Start()
    {
        dataBind.BindText(depart, x => x.popCount, popCount);
    }

    // Update is called once per frame
    void Update()
    {

    }
}