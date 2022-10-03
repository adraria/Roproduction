using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject room0, room1, room2, room3;
    [SerializeField] private Material mat1, mat2;
    [SerializeField] private GameObject PARprefab;
    private float nextLandmark = 10f;
    private GameObject roomLeft, roomOfFocus, roomRight, roomFR;
    private float w = 5f;
    private float startTime;
    private bool created = false;
    private bool endScreen = false;

    // Start is called before the first frame update
    void Start()
    {
        roomLeft = room0;
        roomOfFocus = room1;
        roomRight = room2;
        roomFR = room3;
        startTime = Time.time;
        Time.timeScale = 0;
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
        if (x < 5) {
            return 0;
        } else {
            return -100f * floor((x - 5f) / 10f) - comp(basedmod((x - 5f), 10f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        if (Input.anyKey && Time.timeScale == 0) {
            if (endScreen) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                GlobalVars.reset();
                endScreen = false;
            } else {
                Time.timeScale = 1;
            }
        }
        Ray pointRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(pointRay, out RaycastHit hit, 100)) {
            if (Input.GetMouseButtonDown(0) && Time.timeScale != 0) {
                if (hit.transform.gameObject.tag == "Valve") {
                    ((ValveBeh) hit.transform.gameObject.GetComponent<MonoBehaviour>()).raiseSpeed();
                } else if (hit.transform.gameObject.tag == "Button") {
                    ((ButtonCont) hit.transform.gameObject.GetComponent<MonoBehaviour>()).Press();
                } else if (hit.transform.gameObject.tag == "Rat") {
                    ((RatBeh) hit.transform.gameObject.GetComponent<MonoBehaviour>()).killRat();
                }
            }
        }
        float par = -pointRay.origin.y / pointRay.direction.y;
        GlobalVars.instance.groundx = pointRay.origin.x + pointRay.direction.x * par;
        GlobalVars.instance.groundz = pointRay.origin.z + pointRay.direction.z * par;
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
            GlobalVars.instance.roomNumber += 1;
            created = false;
            if (GlobalVars.instance.completedChallenges < GlobalVars.instance.numChallenges) {
                GlobalVars.instance.lives -= (GlobalVars.instance.numChallenges - GlobalVars.instance.completedChallenges);
                GlobalVars.instance.numChallenges = GlobalVars.instance.completedChallenges;
            } else {
                GlobalVars.instance.numChallenges += 1; 
            }
            ((RoomBeh) roomOfFocus.GetComponent<MonoBehaviour>()).spawnNewChallenges(GlobalVars.instance.numChallenges);
            GlobalVars.instance.completedChallenges = 0;
            nextLandmark += 10;
        }
        if (GlobalVars.instance.lives <= 0 || GlobalVars.instance.numChallenges <= 0) {
            Time.timeScale = 0;
            endScreen = true;
        }
    }
}
