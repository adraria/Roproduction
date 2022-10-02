using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCont : MonoBehaviour {

    [SerializeField] private GameObject Button;
    [SerializeField] private AnimationCurve pushCurve;
    [SerializeField] private float pushDistance = 1f;
    [SerializeField] private float pushTime = 0.5f;
    
    private float animStart;
    private Vector3 startPos;
    
    
    // state the button is in
    // possible states: "out" "in" "going in" "going out"
    private string state = "out";

    public string GetState() {
        return state;
    }

    public bool PushedIn() {
        return state == "in" || state == "going in";
    }

    public void Press() {
        if(state == "out") {
            animStart = Time.time;
            state = "going in";
        } else if(state == "going out") {
            animStart = Time.time - (pushTime - (Time.time - animStart));
            state = "going in";
        } else if(state == "in"){
            animStart = Time.time;
            state = "going out";
        } else if(state == "going in"){
            animStart = Time.time - (pushTime - (Time.time - animStart));
            state = "going out";
        } else {
            print("SOMETHING WENT WRONG IN THE BUTTON CODE");
        }
    }

    // Start is called before the first frame update
    void Start() {
        startPos = Button.transform.localPosition;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Press();
        }
        //print(state);
        // Updates the button position if it is going out or in
        if(state == "going in") {
            // if the time is up set the the button to its pushed in state
            if(Time.time >= animStart + pushTime) {
                state = "in";
                Button.transform.localPosition = startPos + new Vector3(0f, 0f, -pushDistance);
            } else {
                Button.transform.localPosition = startPos + new Vector3(0f, 0f, 
                    - (pushCurve.Evaluate((Time.time - animStart) / pushTime) * pushDistance) 
                );
            }

        } else if(state == "going out"){
            
            // if the time is up set the the button to its pushed out
            if(Time.time >= animStart + pushTime) {
                state = "out";
                Button.transform.localPosition = startPos;
            } else {
                Button.transform.localPosition = startPos + new Vector3(0f, 0f, 
                    - (pushCurve.Evaluate(1 - ((Time.time - animStart) / pushTime)) * pushDistance) 
                );
            }
        }
        
    }
}
