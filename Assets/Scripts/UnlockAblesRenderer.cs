using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnlockAblesRenderer : MonoBehaviour {

    public Image[] unlocks;
	// Use this for initialization
	void Start () {
        unlocks[0] = GameObject.Find("Canvas/Unlockables/Campfire").GetComponent<Image>();
        unlocks[0].fillAmount = (0.33F * this.GetComponent<ProgressionManager>().unlocks[0].level);
        GameObject.Find("Canvas/Unlockables/Campfire/Text").GetComponent<Text>().text =
        this.GetComponent<ProgressionManager>().unlocks[0].level.ToString();
    }

    void OnLevelWasLoaded(int level) {
        if(level == 0) {
            unlocks[0] = GameObject.Find("Canvas/Unlockables/Campfire").GetComponent<Image>();
            unlocks[0].fillAmount = (0.33F * this.GetComponent<ProgressionManager>().unlocks[0].level);
            GameObject.Find("Canvas/Unlockables/Campfire/Text").GetComponent<Text>().text =
            this.GetComponent<ProgressionManager>().unlocks[0].level.ToString();
        }
    }

}
