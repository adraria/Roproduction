using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressCounterCont : MonoBehaviour
{
    [SerializeField] private NumberController progressCont, totalCont;

    [SerializeField] private float numberStep = -1.2f;

    public int completed;
    public int total;

    private Vector3 initialLocation;

    void Start() {
        initialLocation = totalCont.transform.localPosition;
    }

    // Update is called once per frame
    void Update() {
        total = GlobalVars.instance.numChallenges;
        completed = GlobalVars.instance.completedChallenges;

        totalCont.transform.localPosition = initialLocation + new Vector3(numberStep *((int) Mathf.Log10(total)), 0f,0f);
        totalCont.SetNumber((float) total);
        progressCont.SetNumber((float) completed);

    }
}
