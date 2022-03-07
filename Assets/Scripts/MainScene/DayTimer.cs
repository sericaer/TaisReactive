using Tais.GSessions;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class DayTimer : MonoBehaviour
{
    public Button speedInc;
    public Button speedDec;
    public Toggle speedPause;

    public int speed { get; set; }
    public bool isSysPause { get; set; }

    public bool isUserPause => speedPause.isOn;

    public bool isPause => isSysPause || isUserPause;

    public int MAX_SPEED => 4;
    public int MIN_SPEED => 1;

    [Serializable]
    public class OnTimerEvent : UnityEvent { };

    
    public OnTimerEvent onTimer;

    void Start()
    {
        isSysPause = false;

        speed = 1;

        speedInc.onClick.AddListener(() =>
        {
            speed++;
            UpdateSpeedControl();
        });

        speedDec.onClick.AddListener(() =>
        {
            speed--;
            UpdateSpeedControl();
        });

        speedPause.onValueChanged.AddListener((value) =>
        {
            UpdateSpeedControl();
        });

        StartCoroutine(OnTimer());
    }

    private void UpdateSpeedControl()
    {
        speedInc.interactable = !speedPause.isOn && speed < MAX_SPEED;
        speedDec.interactable = !speedPause.isOn && speed > MIN_SPEED;
    }

    private IEnumerator OnTimer()
    {
        yield return new WaitForSeconds(1.0f / speed);
        yield return new WaitUntil(() => !isPause);

        onTimer.Invoke();

        StartCoroutine(OnTimer());
    }

    class EventManager
    {
        public static EventManager inst;

        internal IEnumerable<GEvent> OnDayInc(GSession session)
        {
            yield return new GEvent();
        }
    }

    class GEvent
    {

    }
}
