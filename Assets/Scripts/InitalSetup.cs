using UnityEngine;

public class InitalSetup : MonoBehaviour 
{
    public GameObject Instance;
    public GameObject IntroText1;
    public GameObject IntroText2;

    void Awake ()
    {
        if (!GameObject.Find("GameManager")) 
        {
            GameObject gameManager = Instantiate(Instance);
            gameManager.name = Instance.name;
            
            IntroText1.SetActive(true);
            IntroText2.SetActive(true);
        }
    }
}
