using UnityEngine;
using System.Collections;

public class ProgressionManager : MonoBehaviour {

    // Use this for initialization
    public GameObject[] unlocks;
    public int missionCounter;
    void Start () {
        foreach(GameObject g in unlocks)
        {
            g.SetActive(false);
        }
        UnlockObject("Hut");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UnlockObject(string objectName)
    {
        foreach(GameObject g in unlocks)
        {
            if (g.name == objectName)
                g.SetActive(true);
        }
    }
}
