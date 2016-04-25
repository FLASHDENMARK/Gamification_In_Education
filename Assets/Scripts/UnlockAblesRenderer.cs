using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnlockAblesRenderer : MonoBehaviour {

    public Image[] unlocks;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        unlocks[0] = GameObject.Find("Canvas/Unlockables/Campfire").GetComponent<Image>();
        unlocks[1] = GameObject.Find("Canvas/Unlockables/Workbench").GetComponent<Image>();
        unlocks[2] = GameObject.Find("Canvas/Unlockables/Furnace").GetComponent<Image>();
        unlocks[3] = GameObject.Find("Canvas/Unlockables/Hut").GetComponent<Image>();

        for(int i = 0; i < unlocks.Length; i++) {
            unlocks[i].fillAmount = (0.33f * this.GetComponent<ProgressionManager>().unlocks[i].level);
            unlocks[i].transform.FindChild("Text").GetComponent<Text>().text =
                this.GetComponent<ProgressionManager>().unlocks[i].level.ToString();
        }
    }

    void OnLevelWasLoaded(int level) {
        if(level == 0) {
            unlocks[0] = GameObject.Find("Canvas/Unlockables/Campfire").GetComponent<Image>();
            unlocks[1] = GameObject.Find("Canvas/Unlockables/Workbench").GetComponent<Image>();
            unlocks[2] = GameObject.Find("Canvas/Unlockables/Furnace").GetComponent<Image>();
            unlocks[3] = GameObject.Find("Canvas/Unlockables/Hut").GetComponent<Image>();

            for(int i = 0; i < unlocks.Length; i++) {
                unlocks[i].fillAmount = (0.33f * this.GetComponent<ProgressionManager>().unlocks[i].level);
                unlocks[i].transform.FindChild("Text").GetComponent<Text>().text =
                    this.GetComponent<ProgressionManager>().unlocks[i].level.ToString();
            }
        }
    }

}
