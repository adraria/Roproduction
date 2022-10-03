using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RDBeh : MonoBehaviour
{

    [SerializeField] private NumberController nc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nc.SetNumber(GlobalVars.instance.roomNumber);
    }
}
