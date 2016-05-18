using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

class CampFireDigManager : MiniGameBase
{
    public List<CampfireDig> shapes = new List<CampfireDig>();
    public GameObject error = null;
    public float lineRendererWidth = 0.05F;

    bool colorChangeRunning = false;
    CampfireDig currentShape = null;

    Color disconnectedColor = Color.grey;
    Color correctColor = Color.green;
    Color wrongColor = Color.red;

    void Awake ()
    {
        base.OnMiniGameStarted();
        StopError();

        foreach (CampfireDig c in shapes)
            c.Initialize(lineRendererWidth);
    }

    void Update ()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            GrabEquation();
        }
        else if (Input.GetMouseButton(0))
        {
            DragConnection();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ConnectEquationWithShape();
        }
    }

    void GrabEquation ()
    {
        if (MouseManager.GetClickedEntity())
        {
            //
            CampfireDig GO = MouseManager.GetClickedEntity().GetComponent<CampfireDig>();
            
            if (GO && shapes.Contains(GO))
            {
                currentShape = GO;
            }            
        }
    }

    void DragConnection ()
    {
        if (currentShape)
        {
            currentShape.SetColor(disconnectedColor);
            currentShape.SetLineRendererPositions(Input.mousePosition);
        }
    }

    void ConnectEquationWithShape ()
    {
        if (currentShape)
        {
            GameObject GO = MouseManager.GetClickedEntity();

            // Check if this object can be matched against
            if (GO && GO.tag == "Matchable")
            {
                currentShape.SetMatch(GO);
                currentShape.SetLineRendererPositions(GO.transform.position);

                currentShape = null;
            }
            else
            {
                currentShape.ResetLineRenderer();
                currentShape.SetMatch(null);

                currentShape = null;
            }
        }
    }

    public void CheckMatches ()
    {
        int correctAnswers = 0;

        // All connections must be set before we can check the results
        if (!AreAllShapesConnected())
        {
            StartError();
            return;
        }

        foreach (CampfireDig c in shapes)
        {
            if (c.CheckCorrectMatch())
            {
                correctAnswers++;
                c.SetColor(correctColor);
            }
            else
            {
                c.SetColor(wrongColor);
                StartCoroutine(ColorChange(c.gameObject, Color.red));
                break;
            }
        }

        // All answers were correct
        if (correctAnswers == shapes.Count)
        {
            base.OnMiniGameCompleted(3);
        }
    }

    // Returns true if all shapes are connected to an equation
    // False if not
    bool AreAllShapesConnected ()
    {
         foreach (CampfireDig c in shapes)
         {
            if (c.match == null)
                return false;
         }

         return true;
    }

    IEnumerator ColorChange (GameObject GO, Color color) 
    {
        colorChangeRunning = true;

        Color baseColor = GO.GetComponent<Text>().color;

        for (int i = 0; i < 2; i++) 
        { 
            Debug.Log(GO.name);
            GO.GetComponent<Text>().color = color;
            yield return new WaitForSeconds(.5f);
            GO.GetComponent<Text>().color = baseColor;
            yield return new WaitForSeconds(.5f);
        }

        colorChangeRunning = false;
    }

    void StartError ()
    {
        error.SetActive(true);

        Invoke("StopError", 1);
    }

    void StopError ()
    {
        error.SetActive(false);
    }
}
