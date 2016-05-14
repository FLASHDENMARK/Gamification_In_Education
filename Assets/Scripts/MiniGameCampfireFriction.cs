using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGameCampfireFriction : MiniGameBase 
{
    public Transform stick;
    public Transform target;
    public Transform target2;

    public Image smoke; 
    public float speed;
    bool atBottom = false;

    GameObject questions;

    void Start () 
    {
        questions = GameObject.Find("Questions");
        base.OnMiniGameStarted();
    }

    void Update () 
    {
        float step = speed * Time.deltaTime;

        if (Vector3.Distance(target.position, stick.position) < 0.1f)
            atBottom = true;
        else if (Vector3.Distance(target2.position, stick.position) < 0.1f)
            atBottom = false;

        // Oscillate the stick between two points
        if (!atBottom)
            stick.position = Vector3.MoveTowards(stick.position, target.position, step);
        else
            stick.position = Vector3.MoveTowards(stick.position, target2.position, step);
    }

    void Progress (int questionNumber) 
    {
        // Deactivate the current question
        Transform question = questions.transform.GetChild(questionNumber);
        question.gameObject.SetActive(false);

        // Add some cool effects!
        smoke.fillAmount += 0.333f;
        speed += 3.333f;

        // Activate the next question
        questions.transform.GetChild(questionNumber + 1).gameObject.SetActive(true);
    }

    public void CheckAnswers (int questionNumber) 
    {
        Transform question = questions.transform.GetChild(questionNumber);
        string answer = question.GetChild(0).GetComponent<InputField>().text.ToUpper();

        Debug.Log("Answer: " + answer);

        switch (questionNumber) 
        {
            case 0:
                if (answer == "KINETIC") 
                    Progress(questionNumber);
            break;

            case 1:
                float secondAnswer = 0.0F;
                answer = ReplaceCommaWithPeriod(answer);

                if (float.TryParse(answer, out secondAnswer)) 
                {
                    if (secondAnswer == 34.5F)
                        Progress(questionNumber);
                }
            break;

            case 2:
                float thirdAnswer = 0;
                answer = ReplaceCommaWithPeriod(answer);

                if (float.TryParse(answer, out thirdAnswer)) 
                {
                    if (thirdAnswer == 300)
                        base.OnMiniGameCompleted(0);
                }
                else
                {
                    Debug.Log("Failed to Int");
                }

            break;
        }
    }

    // Floats will not parse correctly if ',' are used instead of '.'.
    // Replaces ',' with '.'
    string ReplaceCommaWithPeriod (string s)
    {
        return s.Replace(",", ".");
    }
}
