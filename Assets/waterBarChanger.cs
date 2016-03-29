using UnityEngine;
using System.Collections;

public class waterBarChanger : MonoBehaviour {

    public Vector3 startpos;
    float down = 0.05f;
    public GameObject waterBar;

	// Use this for initialization
	void Start ()
    {
        startpos = waterBar.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        waterBar = this.GetComponent<MouseManager>().GetClickedEntity(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if(waterBar == null)
        {
            return;
        }

        if (waterBar.name == "waterBar")
        {
            if (Input.GetMouseButtonDown(0))
            {
                waterBar.transform.localScale = new Vector3(0.75f, down, 0);
                waterBar.transform.localPosition = startpos + new Vector3(0, down*1.3f, 0);

                down = down + 0.1f;
            }
        }
    }
}
