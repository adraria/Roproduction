using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedBeh : MonoBehaviour
{

    [SerializeField] private Material mat2;
    private float timeCreated;
    private bool matchanged = false;

    // Start is called before the first frame update
    void Start()
    {
        timeCreated = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeCreated > 1f && !matchanged) {
            GetComponent<Renderer>().material = mat2;
            matchanged = true;
        }
    }
}
