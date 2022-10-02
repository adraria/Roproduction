using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSBeh : MonoBehaviour
{

    private float timeCreated;

    // Start is called before the first frame update
    void Start()
    {
        timeCreated = Time.time;
        transform.eulerAngles = new Vector3(-90f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, GlobalVars.instance.ratSymbolAngVel * 100f * Time.deltaTime, 0);
        if (Time.time - timeCreated > 25) {
            Destroy(this.gameObject);
        }
    }
}
