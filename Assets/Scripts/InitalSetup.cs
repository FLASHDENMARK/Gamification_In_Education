using UnityEngine;

// This class handles the initial setup of the game
public class InitalSetup : MonoBehaviour 
{
    public GameObject gameManager;
    public GameObject introText1;
    public GameObject introText2;
    public GameObject languageSelect;

    void Awake ()
    {
        // Does the GameManager object already exist?
        if (!GameObject.Find("GameManager")) 
        {
            // Instantiate a GameManager
            GameObject manager = Instantiate(gameManager);
            // Instantiated objects will have (clone) appended to their name. 
            // Therefore we rename it to the original name
            manager.name = gameManager.name;
            
            // Activate the starting UI elements
            introText1.SetActive(true);
            introText2.SetActive(true);
            languageSelect.SetActive(true);
        }
    }
}
