using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CampfireDig : MonoBehaviour
{
    Vector2 mousePosition;
    Vector3[] positions = new Vector3[2];
    Vector3[] nullVectorArray = new Vector3[2] { Vector3.zero, Vector3.zero };
    public GameObject object1 = null;
    public GameObject object2 = null;
    bool flag;
    
    // Use this for initialization
    void Start()
    {
        this.GetComponent<LineRenderer>().SetWidth(0.1f, 0.1f);
        this.GetComponent<LineRenderer>().SetColors(Color.grey, Color.grey);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("Manager").GetComponent<CampFireDigManager>().clearLineColors();
            if(MouseManager.GetClickedEntity() == this.gameObject)
            {
                object1 = MouseManager.GetClickedEntity();
                this.positions[0] = Camera.main.ScreenToWorldPoint(this.object1.transform.position);
                this.flag = true;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (this.flag && object1 != null)
            {
                this.positions[0] = Camera.main.ScreenToWorldPoint(this.object1.transform.position);
                this.positions[1] = mousePosition;
                this.GetComponent<LineRenderer>().SetPositions(positions);
            }
        }

        if (Input.GetMouseButtonUp(0) && this.flag)
        {
            if(MouseManager.GetClickedEntity() != null && object1 != null){
                if(MouseManager.GetClickedEntity() == object1) {
                    object2 = null;
                    this.positions[0] = object1.transform.position;
                    this.positions[1] = object1.transform.position;
                    object1 = null;
                    this.GetComponent<LineRenderer>().SetPositions(positions);
                    return;
                }
            object2 = MouseManager.GetClickedEntity(/*mousePosition*/);

            this.positions[0] = Camera.main.ScreenToWorldPoint(object1.transform.GetChild(0).position);
            this.positions[1] = object2.transform.position;
            this.GetComponent<LineRenderer>().SetPositions(positions);
            }
            else {
                this.positions[0].x = 0;
                this.positions[0].y = 0;
                this.positions[1].x = 0;
                this.positions[1].y = 0;
                this.GetComponent<LineRenderer>().SetPositions(positions);
            }

            this.flag = false;

        }
    }

    public bool checkAnswers()
    {
        for (int i = 0; i < GameObject.Find("Canvas").transform.childCount -1; i++ ){
           if (GameObject.Find("Canvas").transform.GetChild(i).GetComponent<CampfireDig>().object1 == null ||
                GameObject.Find("Canvas").transform.GetChild(i).GetComponent<CampfireDig>().object1 == null) {
                return false; 
            }
        }
        if (this.object1.name.Contains(this.object2.name)) {
            this.GetComponent<LineRenderer>().SetColors(Color.green, Color.green);
            return true;
        }
        else {
            this.GetComponent<LineRenderer>().SetColors(Color.red, Color.red);
            return false;
        }
    }

}


