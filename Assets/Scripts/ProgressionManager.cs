using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ProgressionManager : MonoBehaviour {

    // Use this for initialization
    public ObjectProgress[] unlocks;

    [System.Serializable]
    public class ObjectProgress
    {
        // fornace, campfire...
        public GameObject asset;
        public int level = 0;
        public int[] toUnlock;
    }

    void Awake()
    {
    }

    void OnLevelWasLoaded(int level)
    {
        Debug.LogError("GEP");
        unlocks[0].asset = GameObject.Find("Unlockables/CampFire");
        if(Application.loadedLevel == 0)
        unlockObjects();
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
    }

    void UnlockObject(int objectIndex)
    {
        if (unlocks[objectIndex].level == 1) { 
        GameObject toUnlock = unlocks[objectIndex].asset.gameObject;
        Sprite sprite = Resources.Load<Sprite>("CampFire");
        toUnlock.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    }


}
