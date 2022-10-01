using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberController : MonoBehaviour {
    // Segment naming scheme:

    /*
      _       a
    |   |   f   b
      _       g
    |   |   e   c
      _       d
    */

    [SerializeField] private GameObject segmentA, segmentB, segmentC, segmentD, segmentE, segmentF, segmentG;

    //[Tooltip("Number Being Displayed")]
    private int number = 0;

    // Sets the number to be displayed returns false if not 0-9
    public bool SetNumber(int newNum) {
        if(newNum < 0 || newNum > 9) {
            return false;
        } else {
            number = newNum;
            switch(number) {
                case 0:
                    segmentA.SetActive(true);
                    segmentB.SetActive(true);
                    segmentC.SetActive(true);
                    segmentD.SetActive(true);
                    segmentE.SetActive(true);
                    segmentF.SetActive(false);
                    segmentG.SetActive(true);
                    break;
                case 1:
                    segmentA.SetActive(false);
                    segmentB.SetActive(true);
                    segmentC.SetActive(true);
                    segmentD.SetActive(false);
                    segmentE.SetActive(false);
                    segmentF.SetActive(false);
                    segmentG.SetActive(false);
                    break;
                case 2:
                    segmentA.SetActive(true);
                    segmentB.SetActive(true);
                    segmentC.SetActive(false);
                    segmentD.SetActive(true);
                    segmentE.SetActive(true);
                    segmentF.SetActive(true);
                    segmentG.SetActive(false);
                    break;
                case 3:
                    segmentA.SetActive(true);
                    segmentB.SetActive(true);
                    segmentC.SetActive(true);
                    segmentD.SetActive(true);
                    segmentE.SetActive(false);
                    segmentF.SetActive(true);
                    segmentG.SetActive(false);
                    break;
                case 4:
                    segmentA.SetActive(false);
                    segmentB.SetActive(true);
                    segmentC.SetActive(true);
                    segmentD.SetActive(false);
                    segmentE.SetActive(false);
                    segmentF.SetActive(true);
                    segmentG.SetActive(true);
                    break;
                case 5:
                    segmentA.SetActive(true);
                    segmentB.SetActive(false);
                    segmentC.SetActive(true);
                    segmentD.SetActive(true);
                    segmentE.SetActive(false);
                    segmentF.SetActive(true);
                    segmentG.SetActive(true);
                    break;
                case 6:
                    segmentA.SetActive(true);
                    segmentB.SetActive(false);
                    segmentC.SetActive(true);
                    segmentD.SetActive(true);
                    segmentE.SetActive(true);
                    segmentF.SetActive(true);
                    segmentG.SetActive(true);
                    break;
                case 7:
                    segmentA.SetActive(true);
                    segmentB.SetActive(true);
                    segmentC.SetActive(true);
                    segmentD.SetActive(false);
                    segmentE.SetActive(false);
                    segmentF.SetActive(false);
                    segmentG.SetActive(false);
                    break;
                case 8:
                    segmentA.SetActive(true);
                    segmentB.SetActive(true);
                    segmentC.SetActive(true);
                    segmentD.SetActive(true);
                    segmentE.SetActive(true);
                    segmentF.SetActive(true);
                    segmentG.SetActive(true);
                    break;
                case 9:
                    segmentA.SetActive(true);
                    segmentB.SetActive(true);
                    segmentC.SetActive(true);
                    segmentD.SetActive(true);
                    segmentE.SetActive(false);
                    segmentF.SetActive(true);
                    segmentG.SetActive(true);
                    break;
            }
            return true;
        }
    }

    // Start is called before the first frame update
    void Start() {
        SetNumber(number);
    }

    void Update() {
        SetNumber((int)Time.time % 10);
    }
}
