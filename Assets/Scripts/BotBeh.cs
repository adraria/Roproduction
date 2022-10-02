using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBeh : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 180 * Mathf.Atan2(GlobalVars.instance.groundx - transform.position.x, GlobalVars.instance.groundz - transform.position.z) / Mathf.PI, 0);
    }
}
