using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBeh : MonoBehaviour
{

    private GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        cube = ((CameraMovement) (Camera.current.GetComponent<MonoBehaviour>())).cube;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 180 * Mathf.Atan2(cube.transform.position.x - transform.position.x, cube.transform.position.z - transform.position.z) / Mathf.PI, 0);
    }
}
