using UnityEngine;
using System.Collections;

public class ProgressionManager : MonoBehaviour {

    // Use this for initialization
    public GameObject[] unlocks;
    public int missionCounter;
    void Start()
    {
        foreach (GameObject g in unlocks)
        {
            g.SetActive(false);
        }
        UnlockObject(3);
    }
	
    void unlockObjects()
    {
        //Furnace
        for(int j = 0; j < unlocks.Length; j++) { 
            for(int i = 0; i < unlocks.Length; i++) {
                Debug.Log(j +", " + i + ". " + "checking " + unlocks[j].name + " need: " + unlocks[j].GetComponent<ObjectProgress>().toUnlock[i]
                    + " have: " + unlocks[i].GetComponent<ObjectProgress>().level);
                if (unlocks[i].GetComponent<ObjectProgress>().level >= unlocks[j].GetComponent<ObjectProgress>().toUnlock[i])
                {
                    if (i == unlocks.Length-1) {
                        Debug.Log("unlocking: " + unlocks[j].name);
                        UnlockObject(j);
                    }
                } else
                {
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
        unlockObjects();
    }

    void UnlockObject(int objectIndex)
    {
        GameObject toUnlock = unlocks[objectIndex].gameObject;             
        toUnlock.SetActive(true);
    }
}
