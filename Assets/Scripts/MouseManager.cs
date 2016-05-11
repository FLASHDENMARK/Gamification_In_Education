using UnityEngine;

public class MouseManager : MonoBehaviour 
{
    // Returns the object the user has clicked on
    public static GameObject GetClickedEntity ()
    {
        GameObject entity = null;

        // Don't let the user click on objects while the Journal is displaying
        if (!JournalManager.ShowJournal)
        {
            // Converts the mouse position from screen space into world space
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Sends out a 'ray' that checks for objects with Collider Components
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Camera.main.transform.forward);
            // If an object with a Collider Component was hit
            if (hit)
            {
                entity = hit.collider.gameObject;
            }
            else
            {
                // No world space object was hit. Instead check for UI elements (UI elements are screen spaced)
                hit = Physics2D.Raycast(Input.mousePosition, Camera.main.transform.forward);

                if (hit)
                    entity = hit.collider.gameObject;
            }
        }

        // Return the object that was hit. Null if no object was hit
        return entity;
    }
}
