using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBeh : MonoBehaviour
{

    private float timeCreated;

    // Start is called before the first frame update
    void Start()
    {
        timeCreated = Time.time;
        transform.eulerAngles = new Vector3(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeCreated > 25) {
            Destroy(this.gameObject);
        }
    }
}
