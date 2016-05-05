﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnlockablesRenderer : MonoBehaviour 
{
    public Image[] unlocks;

    public void SetProgression ()
    {
        FindUnlocks();

        for (int i = 0; i < unlocks.Length; i++) 
        {
            ProgressionManager PM = this.GetComponent<ProgressionManager>();
            unlocks[i].fillAmount = ((float)PM.unlocks[i].level / (float)PM.unlocks[i].maxLevel);
            unlocks[i].transform.FindChild("Text").GetComponent<Text>().text =
                this.GetComponent<ProgressionManager>().unlocks[i].level.ToString();
        }
    }

    void FindUnlocks ()
    {
        unlocks[0] = GameObject.Find("Canvas/Unlockables/Campfire").GetComponent<Image>();
        unlocks[1] = GameObject.Find("Canvas/Unlockables/Workbench").GetComponent<Image>();
        unlocks[2] = GameObject.Find("Canvas/Unlockables/Furnace").GetComponent<Image>();
        unlocks[3] = GameObject.Find("Canvas/Unlockables/Hut").GetComponent<Image>();
    }
}
