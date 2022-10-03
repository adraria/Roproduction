using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLettersBeh : MonoBehaviour
{

    private float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scale = 3.6f + 0.3f * Mathf.Sin(0.01f * t);
        transform.localScale = new Vector3(scale, scale, scale);
        transform.eulerAngles = new Vector3(-45 + 10 * Mathf.Sin(0.01f * t + 2f), 10 * Mathf.Sin(0.01f * t + 4f), 0);
        t++;
    }
}
