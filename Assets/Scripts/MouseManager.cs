using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MouseManager : MonoBehaviour {

    Vector2 mousePosition;
    ProgressionManager GameManagerProgressionManager;
    // Use this for initialization
    void Start() {

    }

    void StartMinigame()
    {
        GameManagerProgressionManager = GameObject.Find("GameManager").GetComponent<ProgressionManager>();
        if(GetClickedEntity(mousePosition).name == "CampFire"){
            GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text = "";
            int index = 0;
            bool flag = false;
            foreach(int i in GameManagerProgressionManager.unlocks[0].toUnlock) {
                if(GameManagerProgressionManager.unlocks[index].level < i) {
                    GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text +=
                   GameManagerProgressionManager.unlocks[index].asset.name +
                        " needs level: " + i + "\n";
                    flag = true;
                }
                index++;
            }
            if(!flag)
                try {
                    SceneManager.LoadScene(GameManagerProgressionManager.unlocks[0]
                .scenes[GameManagerProgressionManager.unlocks[0].level]);
                } catch (IndexOutOfRangeException) {
                    GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text = "No more levels for this unlockable.";
                }
        }

        if (GetClickedEntity(mousePosition).name == "Workbench") {
            GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text = "";
            int index = 0;
            bool flag = false;
            foreach (int i in GameManagerProgressionManager.unlocks[1].toUnlock) {
                if (GameManagerProgressionManager.unlocks[index].level < i) {
                    GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text +=
                   GameManagerProgressionManager.unlocks[index].asset.name +
                        " needs level: " + i + "\n";
                    flag = true;
                }
                index++;
            }
            if (!flag)
                SceneManager.LoadScene(GameManagerProgressionManager.unlocks[1]
                    .scenes[GameManagerProgressionManager.unlocks[1].level]);
        }

        if (GetClickedEntity(mousePosition).name == "Furnace") {
            GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text = "";
            int index = 0;
            bool flag = false;
            foreach (int i in GameManagerProgressionManager.unlocks[2].toUnlock) {
                if (GameManagerProgressionManager.unlocks[index].level < i) {
                    GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text +=
                   GameManagerProgressionManager.unlocks[index].asset.name +
                        " needs level: " + i + "\n";
                    flag = true;
                }
                index++;
            }
            if (!flag)
                SceneManager.LoadScene(GameManagerProgressionManager.unlocks[2]
                    .scenes[GameManagerProgressionManager.unlocks[2].level]);
        }

        if (GetClickedEntity(mousePosition).name == "Hut") {
            GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text = "";
            int index = 0;
            bool flag = false;
            foreach (int i in GameManagerProgressionManager.unlocks[3].toUnlock) {
                if (GameManagerProgressionManager.unlocks[index].level < i) {
                    GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text += 
                   GameManagerProgressionManager.unlocks[index].asset.name +
                        " needs level: " + i + "\n";
                    flag = true;
                }
                index++;
            }
            if (!flag)
                SceneManager.LoadScene(GameManagerProgressionManager.unlocks[3]
                    .scenes[GameManagerProgressionManager.unlocks[3].level]);
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(GetClickedEntity(mousePosition));
            if(GetClickedEntity(mousePosition))
            StartMinigame();
        }
    }


    void LateUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(mousePosition, Vector2.up * 0.5f, Color.red);
        Debug.DrawRay(mousePosition, Vector2.down * 0.5f, Color.red);
        Debug.DrawRay(mousePosition, Vector2.right * 0.5f, Color.red);
        Debug.DrawRay(mousePosition, Vector2.left * 0.5f, Color.red);
    }



    public GameObject GetClickedEntity(Vector2 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Camera.main.transform.forward);
        if (hit)
        {
            return hit.collider.gameObject;
        }
        hit = Physics2D.Raycast(Input.mousePosition, Camera.main.transform.forward);
        if (hit)
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }
}
