using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckAnswer : MonoBehaviour {

    GameObject parent;
    GameObject questions;
	// Use this for initialization
	void Start () {
        parent = this.gameObject;
        questions = GameObject.Find("Questions");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CheckAnswers(int questionNumber) {
        switch (questionNumber) {
            case 0:
                Transform canvas = questions.transform.GetChild(questionNumber);
                Debug.Log(canvas.name);
                if (canvas.GetChild(0).GetComponent<InputField>().text == "Kinetic" ||
                    canvas.GetChild(0).GetComponent<InputField>().text == "kinetic") { 
                    parent.GetComponent<MiniGameCampfireFriction>().smoke.GetComponent<Image>().fillAmount += 0.1f;
                    parent.GetComponent<MiniGameCampfireFriction>().speed += 1;
                    canvas.gameObject.SetActive(false);
                    Debug.Log("Question " + (questionNumber+1).ToString());
                    questions.transform.GetChild(questionNumber + 1).gameObject.SetActive(true);
                }
                break;
        }
    }

}
