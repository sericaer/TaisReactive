using System.Collections;
using System.Collections.Generic;
using Tais.API;
using UnityEngine;
using UnityEngine.UI;

class BufferItem : MonoBehaviour
{
    public Text buffName;

    public IPopBuffer buffer;

    // Start is called before the first frame update
    void Start()
    {
        buffName.text = buffer.GetType().Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
