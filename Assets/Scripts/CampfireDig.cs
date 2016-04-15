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
    GameObject canvas;
    bool flag;
    // Use this for initialization
    void Start()
    {
        this.GetComponent<LineRenderer>().SetWidth(0.1f, 0.1f);
        this.GetComponent<LineRenderer>().SetColors(Color.white, Color.white);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if(Camera.main.GetComponent<MouseManager>().GetClickedEntity(mousePosition) == this.gameObject)
            {
                this.flag = true;
            }
        }

        if (Input.GetMouseButtonUp(0) && this.flag)
        {
            canvas = GameObject.Find("Canvas");
            object1 = this.gameObject;
            object2 = Camera.main.GetComponent<MouseManager>().GetClickedEntity(mousePosition);
            object2.GetComponent<LineRenderer>().SetPositions(nullVectorArray);
            Debug.Log(this.object1.GetComponent<RectTransform>().rect.width * (canvas.GetComponent<RectTransform>().rect.width / Screen.width));
            Debug.Log(Screen.width);
            this.positions[0] = Camera.main.ScreenToWorldPoint(object1.transform.position);
            Vector3 temp = this.object1.transform.position;
            temp.x -= this.object1.GetComponent<RectTransform>().rect.width / 2;
            temp = Camera.main.ScreenToWorldPoint(temp);
            this.positions[0] = temp;
            this.positions[1] = object2.transform.position;
            this.GetComponent<LineRenderer>().SetPositions(positions);
            this.flag = false;
        }

        {


            //Temp store 
            /*
                   GameObject object1 = null;
                    GameObject object2 = null;
                    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (Input.GetMouseButtonDown(0))
                    {
                        object1 = GetComponent<MouseManager>().GetClickedEntity(mousePosition);
                        if (object1 != null)
                        {
                            if(object1.transform.parent.name == "Canvas") 
                                positions[0] = Camera.main.ScreenToWorldPoint(object1.transform.position);
                            else
                                positions[0] = object1.transform.position;
                            positions[0].z = 0;
                        }
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        object2 = GetComponent<MouseManager>().GetClickedEntity(mousePosition);
                        if (object2 != null)
                        {
                            if (object2.transform.parent.name == "Canvas")
                                positions[1] = Camera.main.ScreenToWorldPoint(object2.transform.position);
                            else
                                positions[1] = object2.transform.position;
                            positions[1].z = 0;

                            Debug.Log("positions: " + positions[0] + " " + positions[1]);
                            Debug.DrawLine(positions[0], positions[1]);

                            object1.GetComponent<LineRenderer>().SetPositions(positions);
                            object2.GetComponent<LineRenderer>().SetPositions(nullVectorArray);
                        }
                    }
                    Debug.DrawLine(positions[0], positions[1]);
                }
                */
        }
    }
}


