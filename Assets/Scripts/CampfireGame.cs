using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CampfireGame : MiniGameBase     
{
    GameObject draggedObject = null;
    
    // Update is called once per frame
    void Update () 
    {
        GameObject GO = null;

        if (Input.GetMouseButtonDown(0))
        {
            GO = MouseManager.GetClickedEntity();

            if (GO) 
            {
                if (GO.name == "IgniteButton")
                {
                    StartCoroutine(CompositionCheck());
                    return;
                }

                // Create a copy of the clicked object, allowing the user to drag it
                draggedObject = Instantiate(GO);
                // The dragged object is an UI element, it has to be parented to the Canvas
                // or else it wont draw to the screen
                draggedObject.transform.SetParent(GameObject.Find("Canvas").transform);
            }
        }

        // The object we clicked is now being "dragged"
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
                Destroy(draggedObject);
                if (MouseManager.GetClickedEntity().transform.parent.name == "Fire Triangle")       // Gives an error
                GO = MouseManager.GetClickedEntity().gameObject;
                if (GO)
                    GO.GetComponent<Text>().text = draggedObject.GetComponent<Text>().text;
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
            base.OnMiniGameCompleted(0);
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
