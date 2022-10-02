using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveBeh : MonoBehaviour
{

    private float screwedness = 0;
    private float speed = 0;
    private Vector3 initialPos;
    public bool completed = false;
    private float timeCreated;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        timeCreated = Time.time;
    }
    
    public void raiseSpeed() {
        speed += 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (screwedness < 3f) {
            if (Mathf.Floor(Time.time / 10) == Mathf.Floor(timeCreated / 10)) {
                screwedness += speed * Time.deltaTime;
            }
        } else if (!completed) {
            GlobalVars.instance.completedChallenges += 1;
            completed = true;
        }
        transform.position = initialPos + new Vector3(0, -screwedness, 0f);
        transform.eulerAngles = new Vector3(0f, 72f * screwedness, 0f);
        if (Time.time - timeCreated > 25) {
            Destroy(this.gameObject);
        }
    }
}
