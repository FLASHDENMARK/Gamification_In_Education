using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Furnace_Minigame : MiniGameBase
{

    public GameObject firstGame;
    public GameObject secondGame;
    
    void Start()
    {
        base.OnMiniGameStarted();
    }

    public void Check ()
    {
        StartCoroutine(AnswerCheck());
    }

    IEnumerator AnswerCheck()
    {
        int i = 0, points = 0;

        string[] correctAnswers = { "0.15", "0.40", "0.48", "0.05" };
        string[] correctAnswerscomma = { "0,15", "0,40", "0,48", "0,05"};

        Transform First_Challenge = GameObject.Find("First_Challenge/Answers").transform;

        foreach (Transform element in First_Challenge.transform)
        {
            if ((element.GetChild(2).GetComponent<Text>().text).Contains(correctAnswers[i]) ||
                (element.GetChild(2).GetComponent<Text>().text).Contains(correctAnswerscomma[i]))

            {

                    InputField inputfield = First_Challenge.GetChild(i).GetComponent<InputField>();
                    ColorBlock colorBlock = inputfield.colors;
                    colorBlock.normalColor = Color.green;
                    inputfield.colors = colorBlock;
                    yield return new WaitForSeconds(.5f);
                    colorBlock.normalColor = Color.white;
                    inputfield.colors = colorBlock;
                    yield return new WaitForSeconds(.5f);
                    colorBlock.normalColor = Color.green;
                    inputfield.colors = colorBlock;
                    yield return new WaitForSeconds(.5f);
                    colorBlock.normalColor = Color.white;
                    inputfield.colors = colorBlock;
                    i++;
                    points++;
                }
                else
                {
                    InputField inputfield = First_Challenge.GetChild(i).GetComponent<InputField>();
                    ColorBlock colorBlock = inputfield.colors;
                    colorBlock.normalColor = Color.red;
                    inputfield.colors = colorBlock;
                    yield return new WaitForSeconds(.5f);
                    colorBlock.normalColor = Color.white;
                    inputfield.colors = colorBlock;
                    yield return new WaitForSeconds(.5f);
                    colorBlock.normalColor = Color.red;
                    inputfield.colors = colorBlock;
                    yield return new WaitForSeconds(.5f);
                    colorBlock.normalColor = Color.white;
                    inputfield.colors = colorBlock;
                    i++;
                }
            }
        if (points == 4)
        {
            firstGame.SetActive(false);
            secondGame.SetActive(true);
        }
    }
}	