using UnityEngine;
using System.Collections;

public class InitalSetup : MonoBehaviour {

    public GameObject Instance;

    void Awake()
    {
         
        if (!GameObject.Find("GameManager")) {
            GameObject.Instantiate(Instance);
            GameObject.Find("GameManager(Clone)").name = "GameManager";
        }
    }

}
