using UnityEngine;
using System.Collections;

public class EmptyTinCanChanger : MonoBehaviour {

    public Sprite tinCan10p;
    public GameObject emptyTinCan;
    SpriteRenderer tinCan;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        emptyTinCan = this.GetComponent<MouseManager>().GetClickedEntity(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        tinCan = gameObject.GetComponent<SpriteRenderer>();

        if (emptyTinCan == null)
        {
            return;
        }

        if (emptyTinCan.name == "emptyTinCan")
        {
            if (Input.GetMouseButtonDown(0))
            { 
                tinCan.sprite = tinCan10p;
            }
        }
    }
}
