using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Furnace_Minigame : MiniGameBase
{

    public GameObject firstGame;
    public GameObject secondGame;

    public void Check ()
    {
        StartCoroutine(AnswerCheck());
    }

    IEnumerator AnswerCheck()
    {
        int i = 0, points = 0;

        float[] correctAnswers = { (15.0F / 100.0F), (40.0F / 100.0F), (48.0F / 100.0F), (5.0F / 100.0F) };

        Transform First_Challenge = GameObject.Find("First_Challenge/Answers").transform;

        foreach (Transform element in First_Challenge.transform)
        {
            float count;
            if (float.TryParse((element.GetChild(2).GetComponent<Text>().text), out count))
            {
                if(count == correctAnswers[i])
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
         
        }

        if (points == 4)
        {
            firstGame.SetActive(false);
            secondGame.SetActive(true);
        }
    }
}	