using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MiniGameStarter : MonoBehaviour 
{
    ProgressionManager GameManagerProgressionManager;

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
        bool flag = false;
        Text canvasText = GameObject.Find("Canvas/Panel/Text").GetComponent<Text>();
    	GameManagerProgressionManager = (ProgressionManager)FindObjectOfType(typeof(ProgressionManager));

        foreach (int i in GameManagerProgressionManager.unlocks[levelIndex].toUnlock) 
        {
            if (GameManagerProgressionManager.unlocks[index].level < i) 
            {
				canvasText.text = GameManagerProgressionManager.unlocks[index].asset.name + " need to be level: " + i;
                flag = true;
            }

            index++;
        }
        if (!flag)
        {
            try 
            {
                SceneManager.LoadScene(GameManagerProgressionManager.unlocks[levelIndex].scenes[GameManagerProgressionManager.unlocks[levelIndex].level]);
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
