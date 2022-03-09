using System;
using System.Collections;
using System.Linq;
using Tais.API;
using UnityEngine;
using UnityEngine.UI;

class TabDepartBaseInfo : RxMonoBehaviour
{
    public Text popCount;
    public Toggle[] taxLevelToggles;

    public IDepart depart { get; set; }

    // Use this for initialization
    void Start()
    {
        dataBind.BindText(depart, x => x.popCount, popCount);

        foreach(var taxLevelToggle in taxLevelToggles)
        {
            taxLevelToggle.onValueChanged.RemoveAllListeners();

            taxLevelToggle.onValueChanged.AddListener((isOn) =>
            {
                var level = (DepartTaxLevel)Enum.Parse(typeof(DepartTaxLevel), taxLevelToggle.name);
                if (depart.taxLevel != level)
                {
                    depart.taxLevel = level;
                }
            });

            //var tooltipTrigger = toggle.GetComponent<LazyUpdateTooltipTrigger>();
            //tooltipTrigger.funcGenerateTextInfo = () => GetLevelTooltipInfo(toggle);
        }


        dataBind.BindAction(depart, x => x.taxLevel, (level)=> { taxLevelToggles.Single(x => x.name == level.ToString()).isOn = true; });
    }

    // Update is called once per frame
    void Update()
    {

    }
}