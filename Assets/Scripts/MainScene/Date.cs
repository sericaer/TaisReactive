using Tais.GSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class Date : RxMonoBehaviour
{
    public Text year;
    public Text month;
    public Text day;

    void Start()
    {
        dataBind.BindText(GSession.inst.date, x => x.year, year);
        dataBind.BindText(GSession.inst.date, x => x.month, month);
        dataBind.BindText(GSession.inst.date, x => x.day, day);
    }
}