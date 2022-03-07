using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GEventOption : MonoBehaviour
{
    public Text desc;
    public Button button;

    public IOption option
    {
        get
        {
            return _option;
        }
        set
        {
            _option = value;
            desc.text = _option.desc;

            button.onClick.AddListener(() => _option.Do());
        }
    }

    private IOption _option;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
