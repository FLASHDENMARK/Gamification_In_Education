using UnityEngine;

public class CampfireDig : MonoBehaviour
{
    LineRenderer line;
    // The currently matched object
    public GameObject match;
    // The correct match
    public GameObject correctMatch;

    public Transform lineStart;

    public void Initialize (float width)
    {
        line = GetComponent<LineRenderer>();

        line.SetWidth(width, width);
    }

    public void SetLineRendererPositions (Vector3 mouseScreenPos)
    {
        line.enabled = true;
        Vector3[] worldPositions = {ScreenToWorldPoint(lineStart.position + Vector3.forward), ScreenToWorldPoint(mouseScreenPos + Vector3.forward)};
        
        line.SetPositions(worldPositions);
    }

    public void ResetLineRenderer ()
    {
        line.enabled = false;
    }

    public void SetMatch (GameObject newMatch)
    {
        match = newMatch;
    }

    public bool CheckCorrectMatch ()
    {
        return match == correctMatch;
    }

    public void SetColor (Color c)
    {
        line.SetColors(c, c);
    }

    Vector3 ScreenToWorldPoint (Vector3 screenPoint)
    {
        return Camera.main.ScreenToWorldPoint(screenPoint);
    }
}


