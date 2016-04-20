// Push!!
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

    class CampFireDigManager : MonoBehaviour {
    public GameObject[] Shapes;
    bool ColorChangeRunning = false;
    // Use this for initialization
    public void CheckAllAnswers() {
        int correctAnswers = 0;
        foreach (GameObject GO in Shapes) {
            if (GO.GetComponent<CampfireDig>().object1 == null || GO.GetComponent<CampfireDig>().object2 == null) {
                Debug.Log("Starting coroutine on: " + GO.name);
                if(!ColorChangeRunning)
                StartCoroutine(ColorChange(GO, Color.red));
                return;
            }
            foreach (GameObject GOS in Shapes) {
                if (GOS.GetComponent<CampfireDig>().checkAnswers())
                    correctAnswers++;
            }
            if (correctAnswers == GameObject.Find("Shapes").transform.childCount)
                Debug.LogError("CORRECT!");
        }
    }

    public void clearLineColors() {
        Color clearColor = new Color(0.5f, 0.5f, 0.5f);
        foreach(GameObject GO in Shapes) {
            GO.GetComponent<LineRenderer>().SetColors(clearColor, clearColor);
        }
    }

    IEnumerator ColorChange(GameObject GO, Color color) {
        ColorChangeRunning = true;
        Color baseColor = GO.GetComponent<Text>().color;
        for(int i = 0; i < 3; i++) { 
            Debug.Log(GO.name);
            GO.GetComponent<Text>().color = color;
        yield return new WaitForSeconds(.5f);
            GO.GetComponent<Text>().color = baseColor;
        yield return new WaitForSeconds(.5f);
        }
        ColorChangeRunning = false;
    }

}
