using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CampfireGame : MonoBehaviour {
    string CurrentResource = null;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        if (Input.GetMouseButtonDown(0))
        {
            CurrentResource = GetComponent<MouseManager>().GetClickedEntity(mousePosition) 
                != null ? GetComponent<MouseManager>().GetClickedEntity(mousePosition).GetComponent<Text>().text : null;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(CurrentResource);
            if (GetComponent<MouseManager>().GetClickedEntity(mousePosition))
            GetComponent<MouseManager>().GetClickedEntity(mousePosition).GetComponent<Text>().text = CurrentResource;
        }

	}
}
