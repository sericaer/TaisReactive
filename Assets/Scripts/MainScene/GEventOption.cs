using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GEventOption : MonoBehaviour
{
    public Text desc;
    public Button button;

    public GEvent.Option option
    {
        get
        {
            return _option;
        }
        set
        {
            _option = value;
            desc.text = _option.desc;
        }
    }

    private GEvent.Option _option;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
