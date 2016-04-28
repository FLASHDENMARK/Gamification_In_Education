using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CampfireGame : MonoBehaviour 
{

    MouseManager MM;

    string CurrentResource = null;
    // Use this for initialization
    
    void Start () 
    {
        MM = GameObject.Find("GameManager").GetComponent<MouseManager>();
      // UIRelay.TextNotification("Making Fire!", "Now, to make a fire, i need three components. If only i can remember which ones it is... \n\n\nDrag the correct components, to the fire triangle and give it a shot.");
    }

    public GameObject GO = null;
    GameObject draggedObject;
    // Update is called once per frame
    void Update () {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if(MM.GetClickedEntity(mousePosition) != null) { 
            GO = MM.GetClickedEntity(mousePosition).gameObject;
            if(GO.name == "IgniteButton")
                {
                    StartCoroutine(CompositionCheck());
                    return;
                }
            draggedObject = Instantiate(GO);
            draggedObject.transform.SetParent(GameObject.Find("Canvas").transform);
            CurrentResource = GO != null ? GO.GetComponent<Text>().text : null;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (draggedObject)
            {
                draggedObject.transform.position = Input.mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (draggedObject)
            {
                Debug.Log(CurrentResource);
                Destroy(draggedObject);
                if (MM.GetClickedEntity(mousePosition).transform.parent.name == "Fire Triangle")
                GO = MM.GetClickedEntity(mousePosition).gameObject;
                if (GO)
                    GO.GetComponent<Text>().text = CurrentResource;
            }
        }

	}

    IEnumerator CompositionCheck()
    {
        Button button = GameObject.Find("Canvas/IgniteButton").GetComponent<Button>();
        ColorBlock CB = button.colors;
        List<string> compositionList = new List<string>();
        Transform canvas = GameObject.Find("Canvas/Fire Triangle").transform;
        foreach (Transform child in canvas) { 
            Debug.Log(child.GetComponent<Text>().text);
            compositionList.Add(child.GetComponent<Text>().text);
        }
        
        if (compositionList.Contains("Heat") && compositionList.Contains("Fuel") && compositionList.Contains("O2")) {
            CB.normalColor = Color.green;
            CB.highlightedColor = Color.green;
            button.colors = CB;
            yield return new WaitForSeconds(.5f);
            CB.normalColor = Color.white;
            CB.highlightedColor = Color.white;
            button.colors = CB;
            yield return new WaitForSeconds(.5f);
            CB.normalColor = Color.green;
            CB.highlightedColor = Color.green;
            button.colors = CB;
            yield return new WaitForSeconds(.5f);
            CB.normalColor = Color.white;
            CB.highlightedColor = Color.white;
            button.colors = CB;
            GameObject.Find("GameManager").GetComponent<ProgressionManager>().unlocks[0].level++;
            SceneManager.LoadScene(0);
        }
        else
        {
            CB.normalColor = Color.red;
            CB.highlightedColor = Color.red;
            button.colors = CB;
            yield return new WaitForSeconds(.5f);
            CB.normalColor = Color.white;
            CB.highlightedColor = Color.white;
            button.colors = CB;
            yield return new WaitForSeconds(.5f);
            CB.normalColor = Color.red;
            CB.highlightedColor = Color.red;
            button.colors = CB;
            yield return new WaitForSeconds(.5f);
            CB.normalColor = Color.white;
            CB.highlightedColor = Color.white;
            button.colors = CB;


        }
    }
}
