using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPPMovement : MonoBehaviour
{
    [SerializeField] private bool isFirstRobot = false;
    public float timeCreated;

    // Start is called before the first frame update
    void Start()
    {
        if (isFirstRobot) {
            timeCreated = Time.time - 1;
        } else {
            timeCreated = Time.time;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 16.9 && Time.time - timeCreated < 5) {
            transform.position = transform.position + new Vector3(0f, 20 * Time.deltaTime, 0f);
        }
        if (Time.time - timeCreated > 11 - 0.35247) {
            transform.position = transform.position + new Vector3(0f, -20 * Time.deltaTime, 0f);
        }
        if (Time.time - timeCreated > 12) {
            Destroy(this.gameObject);
        }
    }
}
