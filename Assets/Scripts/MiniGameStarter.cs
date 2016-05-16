using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameStarter : MonoBehaviour 
{
    public Text infoPanel;
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

    // Load a Mini Games for a specific unlockable, if it is available
    void LoadMiniGame (int levelIndex)
    {
        int index = 0;
        bool levelReached = true;
    	progression = (ProgressionManager)FindObjectOfType(typeof(ProgressionManager));

        foreach (int i in progression.unlocks[levelIndex].toUnlock) 
        {
            if (progression.unlocks[index].level < i) 
            {
            	if (Language.IsDanish)
            		infoPanel.text = progression.unlocks[index].asset.name + " skal være level: " + i;
            	else
					infoPanel.text = progression.unlocks[index].asset.name + " need to be level: " + i;

                levelReached = false;
            }

            index++;
        }
        
        if (levelReached)
        {
            try 
            {
                ProgressionManager.ObjectProgress unlockable = progression.unlocks[levelIndex];
                SceneManager.LoadScene(unlockable.scenes[unlockable.level]);
            } 
            catch (IndexOutOfRangeException) 
            {
            	if (Language.IsDanish)
            		infoPanel.text = "Ikke flere levels for dette objekt";
            	else
            		infoPanel.text = "No more levels for this unlockable";
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
