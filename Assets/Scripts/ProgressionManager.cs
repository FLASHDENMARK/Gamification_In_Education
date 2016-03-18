using UnityEngine;
using System.Collections;

public class ProgressionManager : MonoBehaviour {

    // Use this for initialization
    public ObjectProgress[] unlocks;
    public int missionCounter;

    [System.Serializable]
    public class ObjectProgress
    {
        // fornace, campfire...
        public GameObject asset;
        public int level = 0;
        public int[] toUnlock;
    }

    void Start()
    {
        foreach (ObjectProgress g in unlocks)
        {
            g.asset.SetActive(false);
        }
        UnlockObject(3);
    }
	
    void unlockObjects()
    {
        //Furnace
        for(int j = 0; j < unlocks.Length; j++) { 
            for(int i = 0; i < unlocks.Length; i++) {
                Debug.Log(j +", " + i + ". " + "checking " + unlocks[j].asset.name + " need: " + unlocks[j].toUnlock[i]
                    + " have: " + unlocks[i].level);
                if (unlocks[i].level >= unlocks[j].toUnlock[i])
                {
                    if (i == unlocks.Length-1) {
                        Debug.Log("unlocking: " + unlocks[j].asset.name);
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
        GameObject toUnlock = unlocks[objectIndex].asset.gameObject;             
        toUnlock.SetActive(true);
    }


}
