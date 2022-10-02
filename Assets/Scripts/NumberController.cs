using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberController : MonoBehaviour {
    [Tooltip("Only sets num on start of objects life. Does not do anything at runtime")]
    [SerializeField] private float defaultValue;
    [Tooltip("Put Digits in from left to right")]
    [SerializeField] private List<DigitController> digitList;
    [Tooltip("Number of Total Digits and number of digits after decimal")]
    [SerializeField] private int digits, decimals;
    [Tooltip("Shows leading zeros in counter if true")]
    [SerializeField] private bool showAllZeros = false;
    private float currNum = 12.3456789f;

    // returns true if newNum will mostly fit false otherwise
    // will display the float one way or another
    // when false number may be cut off
    public bool SetNumber(float newNum) {
        currNum = Mathf.Round(Mathf.Abs(newNum * Mathf.Pow(10, decimals)));
        int displayDigits = (int) currNum;
        for(int i = digitList.Count - 1; i >= 0; i--){
            if(i >= digits - decimals - 1 || displayDigits != 0 || showAllZeros) {
                digitList[i].SetDigit(displayDigits % 10);
            } else {
                digitList[i].SetDigit(-1);
            }
            displayDigits = displayDigits / 10;
        }

        return Mathf.Log10(displayDigits) < digits;
    }

    // Start is called before the first frame update
    void Start() {
        SetNumber(defaultValue);
    }
}
