using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPPMovement : MonoBehaviour
{

    public float timeCreated;

    // Start is called before the first frame update
    void Start()
    {
        timeCreated = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 16.9) {
            transform.position = transform.position + new Vector3(0f, 20 * Time.deltaTime, 0f);
        }
        if (Time.time - timeCreated > 20) {
            Destroy(this.gameObject);
        }
    }
}
