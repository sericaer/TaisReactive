using System.Collections;
using Tais.API;
using UnityEngine;
using UnityEngine.UI;

class DepartDetail : RxMonoBehaviour
{
    public Text departName;
    public TabDepartBaseInfo tabDepartBaseInfo;

    public IDepart depart
    {
        get
        {
            return _depart;
        }
        set
        {
            _depart = value;
            departName.text = _depart.name;

            tabDepartBaseInfo.depart = _depart;
        }
    }

    private IDepart _depart;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}