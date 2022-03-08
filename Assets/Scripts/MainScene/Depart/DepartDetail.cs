using System.Collections;
using Tais.API;
using UnityEngine;

class DepartDetail : RxMonoBehaviour
{
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