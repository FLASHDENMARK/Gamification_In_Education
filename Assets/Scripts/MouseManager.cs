using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour {

    Vector2 mousePosition;

    // Use this for initialization
    void Start() {

    }

    void StartMinigame()
    {
        if(GetClickedEntity(mousePosition).name == "CampFire"){
            GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text = "";
            int index = 0;
            bool flag = false;
            foreach(int i in GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[0].toUnlock) {
                if(GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[index].level < i) {
                    GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text +=
                   GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[index].asset.name +
                        " needs level: " + i + "\n";
                    flag = true;
                }
                index++;
            }
            if(!flag)
            SceneManager.LoadScene(1 + GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[0].level);
        }

        if (GetClickedEntity(mousePosition).name == "Workbench") {
            GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text = "";
            int index = 0;
            bool flag = false;
            foreach (int i in GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[1].toUnlock) {
                if (GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[index].level < i) {
                    GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text +=
                   GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[index].asset.name +
                        " needs level: " + i + "\n";
                    flag = true;
                }
                index++;
            }
            if (!flag)
                SceneManager.LoadScene(1 + GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[0].level);
        }

        if (GetClickedEntity(mousePosition).name == "Furnace") {
            GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text = "";
            int index = 0;
            bool flag = false;
            foreach (int i in GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[2].toUnlock) {
                if (GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[index].level < i) {
                    GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text +=
                   GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[index].asset.name +
                        " needs level: " + i + "\n";
                    flag = true;
                }
                index++;
            }
            if (!flag)
                SceneManager.LoadScene(1 + GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[0].level);
        }

        if (GetClickedEntity(mousePosition).name == "Hut") {
            GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text = "";
            int index = 0;
            bool flag = false;
            foreach (int i in GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[3].toUnlock) {
                if (GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[index].level < i) {
                    GameObject.Find("Canvas/Panel/Text").GetComponent<Text>().text += 
                   GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[index].asset.name +
                        " needs level: " + i + "\n";
                    flag = true;
                }
                index++;
            }
            if (!flag)
                SceneManager.LoadScene(1 + GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[0].level);
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
