using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckAnswer : MiniGameBase {

    GameObject parent;
    GameObject questions;
	// Use this for initialization
	public void Start () {
        parent = this.gameObject;
        questions = GameObject.Find("Questions");
	}
	
    void Awake() {
        base.OnMiniGameStarted();
    }

	// Update is called once per frame
	void Update () {
	
	}

    public void complete() {
        base.OnMiniGameCompleted(0);
    }

    void progress(int questionNumber) {
        Transform canvas = questions.transform.GetChild(questionNumber);
        parent.GetComponent<MiniGameCampfireFriction>().smoke.GetComponent<Image>().fillAmount += 0.333f;
        parent.GetComponent<MiniGameCampfireFriction>().speed += 3.333f;
        canvas.gameObject.SetActive(false);
        questions.transform.GetChild(questionNumber + 1).gameObject.SetActive(true);
    }

    public void CheckAnswers(int questionNumber) {
        Transform canvas = questions.transform.GetChild(questionNumber);
        switch (questionNumber) {
            case 0:
                if (canvas.GetChild(0).GetComponent<InputField>().text == "Kinetic" ||
                    canvas.GetChild(0).GetComponent<InputField>().text == "kinetic") {
                    progress(questionNumber);
                }
                break;

            case 1:
                if (canvas.GetChild(0).GetComponent<InputField>().text == "34,5" ||
                    canvas.GetChild(0).GetComponent<InputField>().text == "34.5") {
                    progress(questionNumber);
                }
                break;
            case 2:
                if (canvas.GetChild(0).GetComponent<InputField>().text == "300" ||
                    canvas.GetChild(0).GetComponent<InputField>().text == "300.0"){
                    complete();
                }
                break;
        }
    }

}
