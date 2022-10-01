using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberController : MonoBehaviour {
    [Tooltip("Put Digits in from left to right")]
    [SerializeField] private List<DigitController> digitList;
    [Tooltip("Number of Total Digits and number of digits after decimal")]
    [SerializeField] private int digits, decimals;
    
    private float currNum = 12.3456789f;

    // returns true if newNum will mostly fit false otherwise
    // will display the float one way or another
    // when false number may be cut off
    public bool SetNumber(float newNum) {
        int displayDigits = (int) Mathf.Round(Mathf.Abs(newNum * Mathf.Pow(10, decimals)));
        for(int i = digitList.Count - 1; i >= 0; i--){
            digitList[i].SetDigit(displayDigits % 10);
            displayDigits = displayDigits / 10;
        }

        return Mathf.Log10(displayDigits) < digits;
    }

    // Start is called before the first frame update
    void Start() {
        SetNumber(currNum);
    }
}
