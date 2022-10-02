using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatBeh : MonoBehaviour
{

    private float timeCreated;
    private float enterScreen;
    private bool journeyBegan = false;
    private bool journeyEnded = false;
    private float fallVel = 24;
    private float timeKilled;
    private float zVel;

    // Start is called before the first frame update
    void Start()
    {
        timeCreated = Time.time;
        enterScreen = Random.Range(0f, 6f);
    }

    public void killRat() {
        if (journeyBegan && !journeyEnded && Mathf.Floor(Time.time / 10) == Mathf.Floor(timeCreated / 10)) {
            GlobalVars.instance.completedChallenges += 1;
            GlobalVars.instance.ratSymbolAngVel -= 1f;
            timeKilled = Time.time;
            zVel = Random.Range(6f, 6f);
            journeyEnded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeCreated >= enterScreen && !journeyBegan) {
            transform.position = new Vector3(transform.parent.position.x + 40f, transform.position.y, -22f);
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
            journeyBegan = true;
        }
        if (journeyBegan && !journeyEnded) {
            transform.position = transform.position + new Vector3(0, 0, 20 * Time.deltaTime);
        }
        if (journeyEnded) {
            transform.position = transform.position + new Vector3(-8 * Time.deltaTime, -fallVel * Time.deltaTime, zVel * Time.deltaTime);
            fallVel += 8 * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 90 + 1000 * (Time.time - timeKilled));
        }
        if (Time.time - timeCreated > 25 || transform.position.y < -10) {
            Destroy(this.gameObject);
        };
    }
}
