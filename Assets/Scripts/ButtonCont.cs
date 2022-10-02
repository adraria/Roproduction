using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCont : MonoBehaviour {

    [Tooltip("Only used for testing")]
    [SerializeField] private int mouseButton = 0;

    [SerializeField] private GameObject Button;
    [SerializeField] private AnimationCurve pushCurve;
    [SerializeField] private float pushDistance = 1f;
    [SerializeField] private float pushTime = 0.5f;

    private bool interactable = true;

    private bool correctState = true;

    private float animStart;
    private Vector3 startPos;
    
    // state the button is in
    // possible states: "out" "in" "going in" "going out"
    private string state = "out";

    public string GetState() {
        return state;
    }

    // returns true if the button is pushed in false if it is not
    public bool PushedIn() {
        return state == "in" || state == "going in";
    }

    // Returns true if the button is in the correct state
    public bool IsCorrect() {
        return PushedIn() == correctState;
    }

    // sets the material of the button and turns it off from being interactable
    public void TurnOffButton(Material completedMat) {
        Button.GetComponent<Renderer>().material = completedMat;
        interactable = false;
    }

    // Sets the color and the correct state the button is supposed to be int
    public void SetColor(Material newMat, bool neededState) {
        correctState = neededState;
        Button.GetComponent<Renderer>().material = newMat;
    }

    // Changes the state and time to start/change the button animation
    public void Press() {
        // if set to off do not change the state
        if(!interactable) {
            return;
        }
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
        
        ///*
        // used for testing of button press
        if(Input.GetMouseButtonDown(mouseButton)) {
            Press();
        }
        //*/

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
