using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject room0, room1, room2, room3;
    [SerializeField] private Material mat1, mat2;
    [SerializeField] private GameObject PARprefab;
    [SerializeField] public static GameObject cube;
    private float nextLandmark = 10f;
    private GameObject roomLeft, roomOfFocus, roomRight, roomFR;
    private float w = 5f;
    private float startTime;
    private bool created = false;

    // Start is called before the first frame update
    void Start()
    {
        roomLeft = room0;
        roomOfFocus = room1;
        roomRight = room2;
        roomFR = room3;
        startTime = Time.time;
    }

    float basedmod(float x, float d) {
        if (x >= 0) {
            return x % d;
        } else {
            return x % d + d;
        }
    }

    float floor(float x) {
        return x - basedmod(x, 1f);
    }

    float tatan(float x) {
        return (float) Math.Atan(w * (x - 5f)) / w;
    }

    float comp(float x) {
        return 167.686025833f * (tatan(x) - x / (1f + 25f * w * w) - tatan(0f));
    }

    float f (float x) {
        return -100f * floor((x - 5f) / 10f) - comp(basedmod((x - 5f), 10f));
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        Ray pointRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float par = -pointRay.origin.y / pointRay.direction.y;
        cube.transform.position = new Vector3(pointRay.origin.x + pointRay.direction.x * par, 0, pointRay.origin.z + pointRay.direction.z * par);
        transform.position = new Vector3(f(t), transform.position.y, transform.position.z);
        if (t > nextLandmark - 1f && !created) {
            GameObject newbot = Instantiate(PARprefab, new Vector3(-10 * nextLandmark - 18.43574f, -10f, -22.54915f), Quaternion.identity);
            created = true;
        }
        if (t > nextLandmark) {
            roomLeft.transform.position = roomLeft.transform.position + new Vector3(-400f, 0f, 0f);
            GameObject temp = roomLeft;
            roomLeft = roomOfFocus;
            roomOfFocus = roomRight;
            roomRight = roomFR;
            roomFR = temp;
            roomOfFocus.GetComponent<Renderer>().material = mat2;
            roomLeft.GetComponent<Renderer>().material = mat1;
            created = false;
            nextLandmark += 10;
        }
    }
}
