using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MiniGameCampfireFireTriangle : MiniGameBase     
{
    GameObject draggedObject = null;

    // Drag the correct answers here
    public Text heatElement;
    public Text oxygenElement;
    public Text fuelElement;

    void Awake ()
    {
        base.OnMiniGameStarted();
    }
        
    // Update is called once per frame
    void Update () 
    {	
    	// Checks for various "mouse states". 0 means the left mouse button
    	// Is the mouse being clicked?
        if (Input.GetMouseButtonDown(0))
        	CreateDraggableObject();
        // Is the mouse being held down? 
        else if (Input.GetMouseButton(0))
        	DragObject();
        // Has the mouse button been released? 
        else if (Input.GetMouseButtonUp(0))
        	DropObject();
	}

	// Creates a clone of the selected object
	void CreateDraggableObject ()
	{
        GameObject GO = MouseManager.GetClickedEntity();

        // Make sure what we clicked isn't null
        if (GO) 
        {	
        	// Have we clicked on the button that checks if our answers are correct?
            if (GO.name == "Ignite Button")
            {
            	// StartCoroutine is used to call CompositionCheck because it returns an IEnumerator
                StartCoroutine(CompositionCheck());
            }
            // Have we clicked an object with the "Draggable" tag?
            else if (GO.tag == "Draggable")
            {
	            // Create a copy of the clicked object, allowing the user to drag it
	            draggedObject = Instantiate(GO);
	            // Immediately set the position of the object to the mouse position 
	            draggedObject.transform.position = Input.mousePosition; 
	            // The dragged object is an UI element, it has to be parented to the Canvas
	            // or else it wont draw to the screen
	            draggedObject.transform.SetParent(GameObject.Find("Canvas").transform);
            }
        }
	}

	// Makes an object follow the mouse position
	void DragObject ()
	{
        if (draggedObject)
            draggedObject.transform.position = Input.mousePosition;
	}

	void DropObject ()
	{
        if (draggedObject)
        {
            Destroy(draggedObject);
            GameObject GO = MouseManager.GetClickedEntity();

            // Have we released the draggable object above an object with a parent object named "Fire Triangle"?
            if (GO && GO.transform.parent.name == "Fire Triangle")
            	// Set the text of the object we released the draggable object above to the text of the draggable object
				GO.GetComponent<Text>().text = draggedObject.GetComponent<Text>().text;
        }
	}

    IEnumerator CompositionCheck ()
    {
        Button button = GameObject.Find("Canvas/Ignite Button").GetComponent<Button>();
        ColorBlock CB = button.colors;
        List<string> compositionList = new List<string>();
        Transform canvas = GameObject.Find("Canvas/Fire Triangle").transform;

        foreach (Transform child in canvas) 
        { 
            compositionList.Add(child.GetComponent<Text>().text);
        }
        
        if (compositionList.Contains(heatElement.text) && compositionList.Contains(oxygenElement.text) 
            && compositionList.Contains(fuelElement.text)) 
        {
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
            yield return new WaitForSeconds(.5f);

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

    /*IEnumerator CycleColors (ColorBlock block, int reps, float delay, Color color)
    {
    	for (int i = 0; i < reps; i++)
    	{
    		Debug.LogWarning("Cycling");
            block.normalColor = color;
        	block.highlightedColor = color;
        	yield return new WaitForSeconds(delay);
    	}
    }*/
}
