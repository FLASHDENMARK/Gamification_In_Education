using UnityEngine;
using System.Collections;

public class InitalSetup : MonoBehaviour {

    public GameObject Instance;
    public GameObject IntroText1;
    public GameObject IntroText2;
    void Awake()
    {
         
        if (!GameObject.Find("GameManager")) {
            GameObject.Instantiate(Instance);
            GameObject.Find("GameManager(Clone)").name = "GameManager";
            IntroText1.SetActive(true);
            IntroText2.SetActive(true);
        }
    }

}
