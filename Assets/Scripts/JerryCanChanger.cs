using UnityEngine;
using System.Collections;

public class JerryCanChanger : MonoBehaviour {

    public Sprite greenJerryCan60p;
    SpriteRenderer greenjc;
    public GameObject greenJerryCan;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
       greenJerryCan = this.GetComponent<MouseManager>().GetClickedEntity(Camera.main.ScreenToWorldPoint(Input.mousePosition));
       greenjc = gameObject.GetComponent<SpriteRenderer>();

       if (greenJerryCan == null)
        {
            return;
        }
        
       if (greenJerryCan.name == "greenJerryCan")
        {
            if(Input.GetMouseButtonDown(0))
            {
                greenjc.sprite = greenJerryCan60p;

            }
        }
        
	}
}
