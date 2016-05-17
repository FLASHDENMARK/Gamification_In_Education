using UnityEngine;

public class ProgressionManager : MonoBehaviour 
{
    public RendererProgression unlockRenderer;
    public ObjectProgress[] unlocks;
    int miniGamesCompleted = 0;

    [System.Serializable]
    public class ObjectProgress
    {
        // furnace, campfire...
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

    // Callback. Called automatically when a level has been loaded
    void OnLevelWasLoaded (int level)
    {
        FindUnlocks();

        // If the Main Menu was loaded. The Main Menu is always '0'
        if (level == 0) 
        {
            unlockRenderer.SetProgression(); 
         
            if (miniGamesCompleted == CalculateAmountOfMiniGames())
            {
                EndGame end = (EndGame)FindObjectOfType(typeof(EndGame));

                end.GameCompleted();
            }
        }
    }

    public void LevelObjectUp (int obj)
    {
        unlocks[obj].level++;
        miniGamesCompleted++;
    }

    int CalculateAmountOfMiniGames ()
    {
        int games = 0;

        for (int i = 0; i < unlocks.Length; i++)
        {
            for (int b = 0; b < unlocks[i].scenes.Length; b++)
                games++;
        }

        return games;
    }

    void FindUnlocks ()
    {
        unlocks[0].asset = GameObject.Find("Unlockables/CampFire");
        unlocks[1].asset = GameObject.Find("Unlockables/Workbench");
        unlocks[2].asset = GameObject.Find("Unlockables/Furnace");
        unlocks[3].asset = GameObject.Find("Unlockables/Hut");
    }
}
