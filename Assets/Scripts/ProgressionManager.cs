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
        public int maxLevel;
        public int[] toUnlock;
        public int[] scenes;
    }

    void Awake()
    {
        unlocks[0].asset = GameObject.Find("Unlockables/CampFire");
        unlocks[1].asset = GameObject.Find("Unlockables/Workbench");
        unlocks[2].asset = GameObject.Find("Unlockables/Furnace");
        unlocks[3].asset = GameObject.Find("Unlockables/Hut");
    }

    void OnLevelWasLoaded(int level)
    {
        unlocks[0].asset = GameObject.Find("Unlockables/CampFire");
        unlocks[1].asset = GameObject.Find("Unlockables/Workbench");
        unlocks[2].asset = GameObject.Find("Unlockables/Furnace");
        unlocks[3].asset = GameObject.Find("Unlockables/Hut");
        //if(Application.loadedLevel == 0)
        //unlockObjects();
    }
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
