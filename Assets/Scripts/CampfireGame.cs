using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class CampfireGame : MonoBehaviour {
    string CurrentResource = null;
    // Use this for initialization
    
    void Start () {
	
	}
    public GameObject GO = null;
    GameObject draggedObject;
    // Update is called once per frame
    void Update () {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if(GetComponent<MouseManager>().GetClickedEntity(mousePosition) != null) { 
            GO = GetComponent<MouseManager>().GetClickedEntity(mousePosition).gameObject;
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
                if(GetComponent<MouseManager>().GetClickedEntity(mousePosition) != null)
                GO = GetComponent<MouseManager>().GetClickedEntity(mousePosition).gameObject;
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
        string[] composition = new string[3];
        foreach (Transform child in canvas)
            compositionList.Add(child.GetComponent<Text>().text);

        if (compositionList.Contains("Heat") && compositionList.Contains("Fuel") && compositionList.Contains("O2")) {
            CB.normalColor = Color.green;
            button.colors = CB;
            yield return new WaitForSeconds(.5f);
            CB.normalColor = Color.white;
            button.colors = CB;
            yield return new WaitForSeconds(.5f);
            CB.normalColor = Color.green;
            button.colors = CB;
            yield return new WaitForSeconds(.5f);
            CB.normalColor = Color.white;
            button.colors = CB;
        }
        else
        {
            CB.normalColor = Color.red;
            button.colors = CB;
            yield return new WaitForSeconds(.5f);
            CB.normalColor = Color.white;
            button.colors = CB;
            yield return new WaitForSeconds(.5f);
            CB.normalColor = Color.red;
            button.colors = CB;
            yield return new WaitForSeconds(.5f);
            CB.normalColor = Color.white;
            button.colors = CB;


        }
    }
}
