using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private NumberController number;

    // Update is called once per frame
    void Update(){
        number.SetNumber(10 - Time.time % 10);
    }
}
