using System.Collections;
using System.Collections.Generic;
using Tais.Runtime;
using UnityEngine;
using UnityEngine.UI;

class Player : RxMonoBehaviour
{
    public Text playerName;

    // Start is called before the first frame update
    void Start()
    {
        dataBind.BindText(GSession.inst.player, x => x.name, playerName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
