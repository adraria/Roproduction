using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPannelPuzzle : MonoBehaviour
{
    // Make sure there are more materials in the material list than hints in the hint list

    [SerializeField] private List<GameObject> hintList;
    [SerializeField] private List<ButtonCont> buttonList;
    [SerializeField] private List<Material> materialList;

    [SerializeField] private Material completedMat;

    private List<Material> correctMats;
    private bool completionActionComplete = false;
    private float timeCreated;
    

    // Start is called before the first frame update
    // Sets up the puzzle
    void Start() {
        timeCreated = Time.time;
        correctMats = new List<Material>();

        List<ButtonCont> buttonCopy = new List<ButtonCont>(buttonList);
        // Each loop adds a hint color and removes the 
        for(int i = 0; i < hintList.Count; i++) {
            int currMat = Random.Range(0, materialList.Count);
            correctMats.Add(materialList[currMat]);
            hintList[i].GetComponent<Renderer>().material = materialList[currMat];

            materialList.RemoveAt(currMat);
        }

        // selects random colors for buttons
        while(buttonCopy.Count > 0) {
            // Incorrect Buttons
            if(correctMats.Count == 0) {
                int currMat = Random.Range(0, materialList.Count);
                buttonCopy[0].SetColor(materialList[currMat], false);
                materialList.RemoveAt(currMat);
                buttonCopy.RemoveAt(0);
            // Correct Buttons
            } else {
                int currBut = Random.Range(0, buttonCopy.Count);
                int currMat = Random.Range(0, correctMats.Count);
                buttonCopy[currBut].SetColor(correctMats[currMat], true);
                correctMats.RemoveAt(currMat);
                buttonCopy.RemoveAt(currBut);
            }
        }
    }


    // Update is called once per frame
    void Update() {
        // Checks if all buttons are correct
        bool completed = true;
        foreach(ButtonCont bc in buttonList) {
            if(!bc.IsCorrect()) {
                completed = false;
            }
        }

        // if completed turn off colors and interactability
        if (completed && !completionActionComplete) {
            completionActionComplete = true;
            if (Mathf.Floor(Time.time / 10) == Mathf.Floor(timeCreated / 10)) {
                GlobalVars.instance.completedChallenges += 1;
            }
            foreach(ButtonCont bc in buttonList) {
                bc.TurnOffButton(completedMat);
            }
            foreach(GameObject obj in hintList) {
                obj.GetComponent<Renderer>().material = completedMat;
            }
        }

        if (Time.time - timeCreated > 25) {
            Destroy(this.gameObject);
        }
    }
}
