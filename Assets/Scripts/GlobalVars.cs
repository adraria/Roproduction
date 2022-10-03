using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars
{
    public static GlobalVars instance = new GlobalVars();
    public float groundx = 0f;
    public float groundz = 0f;
    public int numChallenges = 1;
    public int completedChallenges = 0;
    public int lives = 5;
    public float ratSymbolAngVel = 0f;
    public int roomNumber = 1;

    public static void reset() {
        instance = new GlobalVars();
    }
}
