﻿using System;
using System.Collections;
using System.Linq;
using Tais.API;
using UnityEngine;
using UnityEngine.UI;

class TabDepartBaseInfo : RxMonoBehaviour
{
    public Text popCount;
    public Text taxValue;

    public Toggle[] taxLevelToggles;

    public IDepart depart { get; set; }

    // Use this for initialization
    void Start()
    {
        dataBind.BindText(depart, x => x.popCount, popCount);
        dataBind.BindText(depart, x => x.taxSource.value, taxValue);

        var tipTaxSource = taxValue.GetComponent<LazyUpdateTooltipTrigger>();
        tipTaxSource.funcGenerateTextInfo = () =>
        {
            var tipInfo = string.Join("\n", depart.taxSource.subSources.Items.Select(x => $"{x.label} {x.value}"));
            return new (string, string)[] { ("BodyText", tipInfo) };
        };

        dataBind.BindAction(depart, x => x.taxLevel, (level) => { taxLevelToggles.Single(x => x.name == level.ToString()).isOn = true; });

        foreach (var taxLevelToggle in taxLevelToggles)
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
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}