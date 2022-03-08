using System;
using System.Collections;
using Tais.API;
using UnityEngine;
using UnityEngine.UI;

public class GEventPanel : MonoBehaviour
{
    public IGEvent gEvent
    {
        get
        {
            return _gEvent;
        }
        set
        {
            _gEvent = value;

            title.text = _gEvent.title;
            desc.text = _gEvent.desc;

            foreach (var opt in _gEvent.options)
            {
                var optionItem = Instantiate(defaultOptionItem, optionContainer).GetComponent<GEventOption>();
                optionItem.option = opt;

                optionItem.button.onClick.AddListener(() =>
                {
                    Destroy(this.gameObject);
                });
            }

            defaultOptionItem.SetActive(false);
        }
    }

    public Func<bool> onDestory { get; set; }

    public Text title;
    public Text desc;
    public Transform optionContainer;

    public GameObject defaultOptionItem;

    private IGEvent _gEvent;

    private void OnDestroy()
    {
        onDestory?.Invoke();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}