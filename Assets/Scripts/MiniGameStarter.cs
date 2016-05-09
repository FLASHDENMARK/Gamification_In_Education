using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MiniGameStarter : MonoBehaviour 
{
    ProgressionManager progression;

    // Update is called once per frame
    void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
    		GameObject GO = MouseManager.GetClickedEntity();

            if (GO)
                CheckObjectForMiniGame(GO);
        }
    }

    void LoadMiniGame (int levelIndex)
    {
        int index = 0;
        bool levelReached = true;
        Text canvasText = GameObject.Find("Canvas/Panel/Text").GetComponent<Text>();
    	progression = (ProgressionManager)FindObjectOfType(typeof(ProgressionManager));

        foreach (int i in progression.unlocks[levelIndex].toUnlock) 
        {
            if (progression.unlocks[index].level < i) 
            {
				canvasText.text = progression.unlocks[index].asset.name + " need to be level: " + i;
                levelReached = false;
            }

            index++;
        }
        
        if (levelReached)
        {
            try 
            {
                SceneManager.LoadScene(progression.unlocks[levelIndex].scenes[progression.unlocks[levelIndex].level]);
            } 
            catch (IndexOutOfRangeException) 
            {
                canvasText.text = "No more levels for this unlockable.";
            }
        }
    }

    void CheckObjectForMiniGame (GameObject GO)
    {
        if (GO.name == "CampFire")
        	LoadMiniGame(0);
        
        if (GO.name == "Workbench") 
        	LoadMiniGame(1);
        
        if (GO.name == "Furnace") 
        	LoadMiniGame(2);
        
        if (GO.name == "Hut") 
        	LoadMiniGame(3);
    }
}
