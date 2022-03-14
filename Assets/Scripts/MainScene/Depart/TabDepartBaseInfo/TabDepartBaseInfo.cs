using System;
using System.Collections;
using System.Linq;
using Tais.API;
using UnityEngine;
using UnityEngine.UI;

class TabDepartBaseInfo : RxMonoBehaviour
{
    public Text popCount;
    public Text taxValue;
    public Text farmTotal;

    public Toggle[] taxLevelToggles;

    public GameObject defaultPopItem;
    public Transform popContainer;

    public IDepart depart { get; set; }

    // Use this for initialization
    void Start()
    {

        defaultPopItem.SetActive(false);

        dataBind.BindText(depart, x => x.popCount, popCount);
        dataBind.BindText(depart, x => x.farmTotal, farmTotal);
        dataBind.BindText(depart.taxSource, x => x.value, taxValue);
        dataBind.BindAction(depart, x => x.taxLevel, (level) => { taxLevelToggles.Single(x => x.name == level.ToString()).isOn = true; });
            
        dataBind.BindObservableList(depart.pops, OnAddPop, OnRemovePop);

        var tipTaxSource = taxValue.GetComponent<LazyUpdateTooltipTrigger>();
        tipTaxSource.funcGenerateTextInfo = () =>
        {
            var tipInfo = string.Join("\n", depart.taxSource.subSources.Items.Select(x => $"{x.label} {x.value}"));
            return new (string, string)[] { ("BodyText", tipInfo) };
        };

        foreach (var taxLevelToggle in taxLevelToggles)
        {
            taxLevelToggle.onValueChanged.RemoveAllListeners();

            taxLevelToggle.onValueChanged.AddListener((isOn) =>
            {
                var level = (TaxLevel)Enum.Parse(typeof(TaxLevel), taxLevelToggle.name);
                if (depart.taxLevel != level)
                {
                    depart.taxLevel = level;
                }
            });
        }

    }

    private void OnAddPop(IPop pop)
    {
        var popPanel = Instantiate(defaultPopItem, popContainer).GetComponent<PopItem>();
        popPanel.gameObject.SetActive(true);
        popPanel.pop = pop;
    }

    private void OnRemovePop(IPop pop)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

    }
}