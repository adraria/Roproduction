using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBeh : MonoBehaviour
{

    [SerializeField] private Material doneMat;
    private bool pulled = false;
    private float timeCreated;

    // Start is called before the first frame update
    void Start()
    {
        timeCreated = Time.time;
    }

    public void changeState(Ray r) {
        if (!pulled) {
            float param = (transform.position.z - r.origin.z) / r.direction.z;
            float interx = r.origin.x + r.direction.x * param;
            float intery = r.origin.y + r.direction.y * param;
            float leverangle = 180 * Mathf.Atan2(interx - transform.parent.position.x, intery - transform.parent.position.y) / Mathf.PI - 180;
            if (leverangle >= -180 && leverangle <= 0) {
                if (leverangle < -140) {
                    leverangle = -140;
                } else if (leverangle > -40) {
                    if (Mathf.Floor(Time.time / 10) == Mathf.Floor(timeCreated / 10)) {
                        GlobalVars.instance.completedChallenges += 1;
                    }
                    leverangle = -40;
                    gameObject.GetComponent<Renderer>().material = doneMat;
                    pulled = true;
                }
                transform.parent.eulerAngles = new Vector3(leverangle, 90, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
