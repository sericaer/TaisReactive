using System.Collections;
using System.Collections.Generic;
using Tais.GSessions;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public GameObject prefabEventPanel;
    public Canvas uiCanvas;

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
            var instance = (GameObject)Instantiate(prefabEventPanel, uiCanvas.transform);
            instance.GetComponent<GEventPanel>().gEvent = gEvent;
        }
    }
}

public class EventManager
{
    public static EventManager inst = new EventManager();

    internal IEnumerable<GEvent> OnDayInc(GSession inst)
    {
        yield return new GEvent();
        yield break;
    }
}

public class GEvent
{
    public string title { get; private set; }
    public string desc { get; private set; }

    public List<Option> options = new List<Option>();

    public class Option
    {
        public string desc { get; private set; }

        public Option()
        {
            desc = "OPT_TEST";
        }
    }

    public GEvent()
    {
        title = "TTTLE_TEST";
        desc = "DESC_TEST";

        options.Add(new Option());
    }
}