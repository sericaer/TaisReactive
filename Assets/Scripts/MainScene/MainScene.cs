using System;
using System.Collections;
using System.Collections.Generic;
using Tais.GEvents;
using Tais.GSessions;

using UnityEngine;

public class MainScene : MonoBehaviour
{
    public GameObject prefabEventPanel;
    public Canvas uiCanvas;
    public DayTimer dayTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDaysTimer()
    {
        GSession.inst.OnDayInc();

        foreach (var gEvent in GEventManager.inst.OnDayInc(GSession.inst))
        {
            var gEventPanel = Instantiate(prefabEventPanel, uiCanvas.transform).GetComponent<GEventPanel>();
            gEventPanel.gEvent = gEvent;
            gEventPanel.onDestory = () => dayTimer.isSysPause = false;

            dayTimer.isSysPause = true;
        }
    }
}