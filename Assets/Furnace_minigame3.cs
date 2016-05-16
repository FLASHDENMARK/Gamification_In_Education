using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Furnace_minigame3 : MiniGameBase
{
    public void Check()
    {
        StartCoroutine(AnswerCheck3());
    }

    IEnumerator AnswerCheck3()
    {
        int i = 0, Points = 0;
        string[] correctAnswers3 = { "2.8", "4", "5", "6.7", "8.6", "4.6"};
        string[] correctAnswers3comma = { "2,8", "4", "5", "6,7", "8,6", "4,6"};

        Transform Third_Challenge = GameObject.Find("Third_Challenge/Answers").transform;
        foreach (Transform element in Third_Challenge.transform)
        {   
            if ((element.GetChild(2).GetComponent<Text>().text).Contains(correctAnswers3[i]) ||
                (element.GetChild(2).GetComponent<Text>().text).Contains(correctAnswers3comma[i]))
            {

                    InputField inputfield = Third_Challenge.GetChild(i).GetComponent<InputField>();
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
                    Points++;
                }
                else
                {
                    InputField inputfield = Third_Challenge.GetChild(i).GetComponent<InputField>();
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
            if( Points == 6 )
            {
                OnMiniGameCompleted(0);
            }
            }

        }
    }

