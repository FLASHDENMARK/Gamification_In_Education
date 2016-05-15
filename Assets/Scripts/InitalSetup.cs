using UnityEngine;

public class InitalSetup : MonoBehaviour 
{
    public GameObject gameManager;
    public GameObject introText1;
    public GameObject introText2;
    public GameObject languageSelect;

    void Awake ()
    {
        if (!GameObject.Find("GameManager")) 
        {
            GameObject manager = Instantiate(gameManager);
            manager.name = gameManager.name;
            
            introText1.SetActive(true);
            introText2.SetActive(true);
            languageSelect.SetActive(true);
        }
    }
}
