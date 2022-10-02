using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveHeadBeh : MonoBehaviour
{

    [SerializeField] private Material doneMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (((ValveBeh) (transform.parent.gameObject.GetComponent<MonoBehaviour>())).completed) {
            gameObject.GetComponent<Renderer>().material = doneMat;
        }
    }
}
