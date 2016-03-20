using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MouseManager : MonoBehaviour {

    Vector2 mousePosition;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(GetClickedEntity(mousePosition));
        }
    }


    void LateUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(mousePosition, Vector2.up * 0.5f, Color.red);
        Debug.DrawRay(mousePosition, Vector2.down * 0.5f, Color.red);
        Debug.DrawRay(mousePosition, Vector2.right * 0.5f, Color.red);
        Debug.DrawRay(mousePosition, Vector2.left * 0.5f, Color.red);
    }



    public GameObject GetClickedEntity(Vector2 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Camera.main.transform.forward);
        if (hit)
        {
            return hit.collider.gameObject;
        }
        hit = Physics2D.Raycast(Input.mousePosition, Camera.main.transform.forward);
        if (hit)
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }
}
