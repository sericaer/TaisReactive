using System;
using System.Collections;
using System.Collections.Generic;
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

        foreach (var gEvent in EventManager.inst.OnDayInc(GSession.inst))
        {
            var gEventPanel = Instantiate(prefabEventPanel, uiCanvas.transform).GetComponent<GEventPanel>();
            gEventPanel.gEvent = gEvent;
            gEventPanel.onDestory = () => dayTimer.isSysPause = false;

            dayTimer.isSysPause = true;
        }
    }
}

public class EventManager
{
    public static EventManager inst = new EventManager();

    private List<GEvent> gEvents = new List<GEvent>();

    public EventManager()
    {
        gEvents.Add(new GEvent());
    }

    public IEnumerable<IGEvent> OnDayInc(GSession inst)
    {
        foreach(var gEvent in gEvents)
        {
            if(gEvent.isTrigge())
            {
                yield return gEvent;
            }
        }

        yield break;
    }
}

public interface IGEvent
{
    string title { get; }
    string desc { get; }

    IEnumerable<IOption> options { get; }
}

public interface IOption
{
    string desc { get; }

    void Do();
}

public class GEvent : IGEvent
{
    public string title { get; private set; }
    public string desc { get; private set; }

    public IEnumerable<IOption> options => _options;

    private List<IOption> _options = new List<IOption>();

    public class Option : IOption
    {
        public string desc { get; private set; }

        public Option()
        {
            desc = "OPT_TEST";
        }

        public void Do()
        {
            GSession.inst.taxMgr.stock -= 300;
        }
    }

    public GEvent()
    {
        title = "TTTLE_TEST";
        desc = "DESC_TEST";

        _options.Add(new Option());
    }

    public bool isTrigge()
    {
        return true;
    }
}