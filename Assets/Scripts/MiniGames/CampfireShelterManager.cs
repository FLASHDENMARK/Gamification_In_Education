using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

class CampfireShelterManager : MiniGameBase
{
    public List<CampfireShelterPair> shapes = new List<CampfireShelterPair>();
    public GameObject error = null;
    public float lineRendererWidth = 0.05F;

    CampfireShelterPair _currentShape = null;

    Color _disconnectedColor = Color.grey;
    Color _correctColor = Color.green;
    Color _wrongColor = Color.red;

    void Awake ()
    {
        base.OnMiniGameStarted();
        StopError();

        foreach (CampfireShelterPair c in shapes)
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
            CampfireShelterPair GO = MouseManager.GetClickedEntity().GetComponent<CampfireShelterPair>();
            
            if (GO && shapes.Contains(GO))
            {
                _currentShape = GO;
            }            
        }
    }

    void DragConnection ()
    {
        if (_currentShape)
        {
            _currentShape.SetColor(_disconnectedColor);
            _currentShape.SetLineRendererPositions(Input.mousePosition);
        }
    }

    void ConnectEquationWithShape ()
    {
        if (_currentShape)
        {
            GameObject GO = MouseManager.GetClickedEntity();

            // Check if this object can be matched against
            if (GO && GO.tag == "Matchable")
            {
                _currentShape.SetMatch(GO);
                _currentShape.SetLineRendererPositions(GO.transform.position);

                _currentShape = null;
            }
            else
            {
                _currentShape.ResetLineRenderer();
                _currentShape.SetMatch(null);

                _currentShape = null;
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

        foreach (CampfireShelterPair c in shapes)
        {
            if (c.CheckCorrectMatch())
            {
                correctAnswers++;
                c.SetColor(_correctColor);
            }
            else
            {
                c.SetColor(_wrongColor);
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
         foreach (CampfireShelterPair c in shapes)
         {
            if (c.match == null)
                return false;
         }

         return true;
    }

    IEnumerator ColorChange (GameObject GO, Color color) 
    {
        Color baseColor = GO.GetComponent<Text>().color;

        for (int i = 0; i < 2; i++) 
        { 
            Debug.Log(GO.name);
            GO.GetComponent<Text>().color = color;
            yield return new WaitForSeconds(.5f);
            GO.GetComponent<Text>().color = baseColor;
            yield return new WaitForSeconds(.5f);
        }
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
