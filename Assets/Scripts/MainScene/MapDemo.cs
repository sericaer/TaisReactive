using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tais.GSessions;
using UnityEngine;

public class MapDemo : MonoBehaviour
{
    public Transform departDetailParent;

    public GameObject departDetail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDepart1()
    {
        var detail = Instantiate(departDetail, departDetailParent).GetComponent<DepartDetail>();
        detail.depart = GSession.inst.departs.ElementAt(0);
    }

    public void ShowDepart2()
    {
        var detail = Instantiate(departDetail, departDetailParent).GetComponent<DepartDetail>();
        detail.depart = GSession.inst.departs.ElementAt(1);
    }

    public void ShowDepart3()
    {
        var detail = Instantiate(departDetail, departDetailParent).GetComponent<DepartDetail>();
        detail.depart = GSession.inst.departs.ElementAt(2);
    }
}
