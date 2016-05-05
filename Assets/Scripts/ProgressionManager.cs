using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ProgressionManager : MonoBehaviour 
{
    public RendererProgression unlockRenderer;
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

    void Awake ()
    {
        DontDestroyOnLoad(this);
        FindUnlocks();
        unlockRenderer.SetProgression(); 
    }

    void OnLevelWasLoaded (int level)
    {
        FindUnlocks();

        // If the Main Menu was loaded. The Main Menu is always '0'
        if (level == 0) 
            unlockRenderer.SetProgression(); 
    }

    void FindUnlocks ()
    {
        unlocks[0].asset = GameObject.Find("Unlockables/CampFire");
        unlocks[1].asset = GameObject.Find("Unlockables/Workbench");
        unlocks[2].asset = GameObject.Find("Unlockables/Furnace");
        unlocks[3].asset = GameObject.Find("Unlockables/Hut");
    }

    void UnlockObject (int objectIndex)
    {
        if (unlocks[objectIndex].level == 1) 
        { 
            GameObject toUnlock = unlocks[objectIndex].asset.gameObject;
            Sprite sprite = Resources.Load<Sprite>("CampFire");
            toUnlock.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
