using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Furnace_Minigame2 : MiniGameBase
{
    public GameObject secondGame;
    public GameObject thridGame;

    public void Check()
    {
        StartCoroutine(AnswerCheck2());
    }

    IEnumerator AnswerCheck2()
    {
        int i = 0, Points = 0;
        float[] correctAnswers2 = { (180 - 90 - 45), (180 - 35 - 35), (180 - 90 - 25), (180 - 40 - 40), (180 - 90 - 55), (180 - 85 - 50) };

        Transform Second_Challenge = GameObject.Find("Second_Challenge/Answers").transform;
        foreach (Transform element in Second_Challenge.transform)
        {
            float count;
            if (float.TryParse((element.GetChild(2).GetComponent<Text>().text), out count))
            {
                if (count == correctAnswers2[i])
                {
                    InputField inputfield = Second_Challenge.GetChild(i).GetComponent<InputField>();
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
                    InputField inputfield = Second_Challenge.GetChild(i).GetComponent<InputField>();
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
      if(Points == 6)
        {
            secondGame.SetActive(false);
            thridGame.SetActive(true);
        }
    }


}
