using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBeh : MonoBehaviour
{

    [SerializeField] private GameObject valveprefab;
    [SerializeField] private GameObject buttongameprefab;
    [SerializeField] private GameObject ratprefab;
    [SerializeField] private GameObject ratsymbolprefab;

    public void spawnNewChallenges(int n) {
        GlobalVars.instance.ratSymbolAngVel = 0f;
        int numButtonGames = 0;
        bool[] buttonArray = {false, false, false, false};
        bool ratSymbolCreated = false;
        int i = 0;
        while (i < n) {
            float challengeType = Random.Range(0f, 1f);
            if (challengeType > 0.5) {
                bool done = false;
                float valvex = 0, valvez = 0;
                while (!done) {
                    valvex = Random.Range(-36f, 36f);
                    valvez = Random.Range(-18f, 20f);
                    if (valvex * valvex + valvez * valvez > 16 * 16 && (valvex < -10 || valvex > 10 || valvez > 0) && valvez > -16 && (valvex < 32 || valvez > -11)) {
                        done = true;
                    }
                }
                Instantiate(valveprefab, transform.position + new Vector3(valvex, 0.3f, valvez), Quaternion.identity).transform.SetParent(this.transform);
                i++;
            } else if (challengeType > 0.3) {
                if (numButtonGames < 4) {
                    int buttonSlot = 0;
                    bool done = false;
                    while (!done) {
                        buttonSlot = (int) Random.Range(0f, 3.99f);
                        if (!buttonArray[buttonSlot]) {
                            buttonArray[buttonSlot] = true;
                            done = true;
                        }
                    }
                    Instantiate(buttongameprefab, transform.position + new Vector3((buttonSlot % 2) * 50f - 25f, 0f + 12f * (buttonSlot / 2), -20f), Quaternion.identity).transform.SetParent(this.transform);
                    i++;
                    numButtonGames++;
                }
            } else {
                Instantiate(ratprefab, transform.position + new Vector3(100f, Random.Range(0f, 20f), -20f), Quaternion.identity).transform.SetParent(this.transform);
                GlobalVars.instance.ratSymbolAngVel += 1f;
                if (!ratSymbolCreated) {
                    Instantiate(ratsymbolprefab, transform.position + new Vector3(36f, 0, -15f), Quaternion.identity).transform.SetParent(this.transform);
                    ratSymbolCreated = true;
                }
                i++;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
